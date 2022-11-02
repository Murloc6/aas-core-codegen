def _is_leap_year(year: int) -> bool:
    """
    Check if :paramref:`year` is a leap year.

    >>> _is_leap_year(2016)
    True

    >>> _is_leap_year(1700)
    False

    >>> _is_leap_year(1600)
    True

    >>> _is_leap_year(2000)
    True
    """
    # We consider the years B.C. to be one-off.
    #
    # See the note at: https://www.w3.org/TR/xmlschema-2/#dateTime:
    # "'-0001' is the lexical representation of the year 1 Before Common Era
    # (1 BCE, sometimes written "1 BC")."
    #
    # Hence, -1 year in XML is 1 BCE, which is 0 year in astronomical years.
    if year < 0:
        year = abs(year) - 1

    # See: https://en.wikipedia.org/wiki/Leap_year#Algorithm
    if year % 4 > 0:
        return False

    if year % 100 > 0:
        return True

    if year % 400 > 0:
        return False

    return True


_DAYS_IN_MONTH: Mapping[int, int] = {
    1: 31,
    # Please use _is_leap_year if you need to check
    # whether a concrete February has 28 or 29 days.
    2: 29,
    3: 31,
    4: 30,
    5: 31,
    6: 30,
    7: 31,
    8: 31,
    9: 30,
    10: 31,
    11: 30,
    12: 31,
}


_DATE_PREFIX_RE = re.compile(r'^(-?[0-9]+)-([0-9]{2})-([0-9]{2})')


def is_xs_date(value: str) -> bool:
    """
    Check that :paramref:`value` is a valid ``xs:date``.

    We can not use :py:func:`datetime.date.strptime` as it does not
    handle years below 1000 correctly on Windows (*e.g.*, ``-999-01-01``).
    """
    if matches_xs_date(value) is False:
        return False

    # NOTE (mristin, 2022-10-30):
    # We need to match the prefix as zone offsets are allowed in the dates. Optimally,
    # we would re-use the pattern matching from :py:func`matches_xs_date`, but this
    # would make the code generation and constraint inference for schemas much more
    # difficult. Hence, we sacrifice the efficiency a bit for the clearer code & code
    # generation.
    match = _DATE_PREFIX_RE.match(value)
    assert match is not None

    year = int(match.group(1))
    month = int(match.group(2))
    day = int(match.group(3))

    # We do not accept year zero,
    # see the note at: https://www.w3.org/TR/xmlschema-2/#dateTime
    if year == 0:
        return False

    if day <= 0:
        return False

    if month <= 0 or month >= 13:
        return False

    if month == 2:
        max_days = 29 if _is_leap_year(year) else 28
    else:
        max_days = _DAYS_IN_MONTH[month]

    # We accept the zero year for astronomical settings,
    # see: https://en.wikipedia.org/wiki/Year_zero

    if day > max_days:
        return False

    return True


def is_xs_date_time(value: str) -> bool:
    """
    Check that :paramref:`value` is a valid ``xs:dateTime``.

    We can not use :py:func:`datetime.datetime.strptime` as it does not
    handle years below 1000 correctly on Windows (*e.g.*, ``-999-01-01``).
    """
    if matches_xs_date_time(value) is False:
        return False

    date, _ = value.split('T')
    return is_xs_date(date)


def is_xs_date_time_stamp(value: str) -> bool:
    """
    Check that :paramref:`value` is a valid ``xs:dateTimeStamp``.

    We can not use :py:func:`datetime.datetime.strptime` as it does not
    handle years below 1000 correctly on Windows (*e.g.*, ``-999-01-01``).
    """
    if matches_xs_date_time_stamp(value) is False:
        return False

    date, _ = value.split('T')
    return is_xs_date(date)


def is_xs_double(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:double``."""
    # We need to check explicitly for the regular expression since
    # ``float(.)`` is too permissive. For example,
    # it accepts "nan" although only "NaN" is valid.
    # See: https://www.w3.org/TR/xmlschema-2/#double
    if matches_xs_double(value) is False:
        return False

    converted = float(value)

    # Check that the value is either "INF" or "-INF".
    # Otherwise, the value is a decimal which is too big
    # to be represented as a double-precision floating point
    # number.
    #
    # Python simply rounds up/down to ``INF`` and ``-INF``,
    # respectively, if the number is too large.
    # For example: ``float("1e400") == math.inf``
    if (
            math.isinf(converted)
            and value != 'INF'
            and value != '-INF'
    ):
        return False

    return True


def is_xs_float(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:float``."""
    # We need to check explicitly for the regular expression since
    # ``float(.)`` is too permissive. For example,
    # it accepts "nan" although only "NaN" is valid.
    # See: https://www.w3.org/TR/xmlschema-2/#double
    if matches_xs_float(value) is False:
        return False

    converted = float(value)

    # Check that the value is either "INF" or "-INF".
    # Otherwise, the value is a decimal which is too big
    # to be represented as a single-precision floating point
    # number.
    #
    # Python simply rounds up/down to ``INF`` and ``-INF``,
    # respectively, if the number is too large.
    # For example: ``float("1e400") == math.inf``
    if (
            math.isinf(converted)
            and value != 'INF'
            and value != '-INF'
    ):
        return False

    # Python uses double-precision floating point numbers. Since
    # we check for a single-precision one, we have to explicitly
    # see if the number is within a range of a single-precision
    # floating point numbers.
    try:
        _ = struct.pack('>f', converted)
    except OverflowError:
        return False

    return True


def is_xs_g_month_day(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:gMonthDay``."""
    if matches_xs_g_month_day(value) is False:
        return False

    month = int(value[2:4])
    day = int(value[5:7])

    max_days = _DAYS_IN_MONTH[month]
    return day <= max_days


def is_xs_long(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:long``."""
    if matches_xs_long(value) is False:
        return False

    converted = int(value)
    return -9223372036854775808 <= converted <= 9223372036854775807


def is_xs_int(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:int``."""
    if matches_xs_int(value) is False:
        return False

    converted = int(value)
    return -2147483648 <= converted <= 2147483647


def is_xs_short(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:short``."""
    if matches_xs_short(value) is False:
        return False

    converted = int(value)
    return -32768 <= converted <= 32767


def is_xs_byte(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:byte``."""
    if matches_xs_byte(value) is False:
        return False

    converted = int(value)
    return -128 <= converted <= 127


def is_xs_unsigned_long(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:unsignedLong``."""
    if matches_xs_unsigned_long(value) is False:
        return False

    converted = int(value)
    return 0 <= converted <= 18446744073709551615


def is_xs_unsigned_int(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:unsignedInt``."""
    if matches_xs_unsigned_int(value) is False:
        return False

    converted = int(value)
    return 0 <= converted <= 4294967295


def is_xs_unsigned_short(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:unsignedShort``."""
    if matches_xs_unsigned_short(value) is False:
        return False

    converted = int(value)
    return 0 <= converted <= 65535


def is_xs_unsigned_byte(value: str) -> bool:
    """Check that :paramref:`value` is a valid ``xs:unsignedByte``."""
    if matches_xs_unsigned_byte(value) is False:
        return False

    converted = int(value)
    return 0 <= converted <= 255


_DATA_TYPE_DEF_XSD_TO_VALUE_CONSISTENCY: Mapping[
    aas_types.DataTypeDefXsd,
    Callable[[str], bool]
] = {
    aas_types.DataTypeDefXsd.ANY_URI:
    matches_xs_any_uri,
    
    aas_types.DataTypeDefXsd.BASE_64_BINARY:
    matches_xs_base_64_binary,
    
    aas_types.DataTypeDefXsd.BOOLEAN:
    matches_xs_boolean,
    
    aas_types.DataTypeDefXsd.DATE:
    is_xs_date,

    aas_types.DataTypeDefXsd.DATE_TIME:
    is_xs_date_time,

    aas_types.DataTypeDefXsd.DATE_TIME_STAMP:
    is_xs_date_time_stamp,

    aas_types.DataTypeDefXsd.DECIMAL:
    matches_xs_decimal,
    
    aas_types.DataTypeDefXsd.DOUBLE:
    is_xs_double,
    
    aas_types.DataTypeDefXsd.DURATION:
    matches_xs_duration,
    
    aas_types.DataTypeDefXsd.FLOAT:
    is_xs_float,
    
    aas_types.DataTypeDefXsd.G_DAY:
    matches_xs_g_day,
    
    aas_types.DataTypeDefXsd.G_MONTH:
    matches_xs_g_month,
    
    aas_types.DataTypeDefXsd.G_MONTH_DAY:
    is_xs_g_month_day,
    
    aas_types.DataTypeDefXsd.G_YEAR:
    matches_xs_g_year,
    
    aas_types.DataTypeDefXsd.G_YEAR_MONTH:
    matches_xs_g_year_month,
    
    aas_types.DataTypeDefXsd.HEX_BINARY:
    matches_xs_hex_binary,
    
    aas_types.DataTypeDefXsd.STRING:
    matches_xs_string,
    
    aas_types.DataTypeDefXsd.TIME:
    matches_xs_time,
    
    aas_types.DataTypeDefXsd.DAY_TIME_DURATION:
    matches_xs_day_time_duration,
    
    aas_types.DataTypeDefXsd.YEAR_MONTH_DURATION:
    matches_xs_year_month_duration,
    
    aas_types.DataTypeDefXsd.INTEGER:
    matches_xs_integer,
    
    aas_types.DataTypeDefXsd.LONG:
    is_xs_long,
    
    aas_types.DataTypeDefXsd.INT:
    is_xs_int,
    
    aas_types.DataTypeDefXsd.SHORT:
    is_xs_short,
    
    aas_types.DataTypeDefXsd.BYTE:
    is_xs_byte,
    
    aas_types.DataTypeDefXsd.NON_NEGATIVE_INTEGER:
    matches_xs_non_negative_integer,
    
    aas_types.DataTypeDefXsd.POSITIVE_INTEGER:
    matches_xs_positive_integer,
    
    aas_types.DataTypeDefXsd.UNSIGNED_LONG:
    is_xs_unsigned_long,
    
    aas_types.DataTypeDefXsd.UNSIGNED_INT:
    is_xs_unsigned_int,

    aas_types.DataTypeDefXsd.UNSIGNED_SHORT:
    is_xs_unsigned_short,

    aas_types.DataTypeDefXsd.UNSIGNED_BYTE:
    is_xs_unsigned_byte,

    aas_types.DataTypeDefXsd.NON_POSITIVE_INTEGER:
    matches_xs_non_positive_integer,
    
    aas_types.DataTypeDefXsd.NEGATIVE_INTEGER:
    matches_xs_negative_integer,
}
assert all(
    data_type_def_xsd in _DATA_TYPE_DEF_XSD_TO_VALUE_CONSISTENCY
    for data_type_def_xsd in aas_types.DataTypeDefXsd 
)


def value_consistent_with_xsd_type(
        value: str,
        value_type: aas_types.DataTypeDefXsd
) -> bool:
    """
    Check that :paramref:`value` is consistent with the given
    :paramref:`value_type`.
    """
    return _DATA_TYPE_DEF_XSD_TO_VALUE_CONSISTENCY[value_type](value)
