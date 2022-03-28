/*
 * This code has been automatically generated by aas-core-codegen.
 * Do NOT edit or append.
 */

namespace AasCore.Aas3
{
    public static class Visitation
    {
        /// <summary>
        /// Define the interface for a visitor which visits the instances of the model.
        /// </summary>
        public interface IVisitor
        {
            public void Visit(IClass that);
            public void Visit(Resource that);
            public void Visit(Qualifier that);
            public void Visit(ReferenceElement that);
            public void Visit(GlobalReference that);
            public void Visit(ModelReference that);
            public void Visit(Key that);
            public void Visit(Extension that);
            public void Visit(AdministrativeInformation that);
            public void Visit(AssetAdministrationShell that);
            public void Visit(AssetInformation that);
            public void Visit(IdentifierKeyValuePair that);
            public void Visit(Submodel that);
            public void Visit(SubmodelElementList that);
            public void Visit(SubmodelElementStruct that);
            public void Visit(Property that);
            public void Visit(MultiLanguageProperty that);
            public void Visit(Range that);
            public void Visit(Blob that);
            public void Visit(File that);
            public void Visit(AnnotatedRelationshipElement that);
            public void Visit(BasicEventElement that);
            public void Visit(EventPayload that);
            public void Visit(Entity that);
            public void Visit(BasicEvent that);
            public void Visit(Operation that);
            public void Visit(OperationVariable that);
            public void Visit(Capability that);
            public void Visit(ConceptDescription that);
            public void Visit(View that);
            public void Visit(ValueReferencePair that);
            public void Visit(ValueList that);
            public void Visit(DataSpecificationIec61360 that);
            public void Visit(DataSpecificationPhysicalUnit that);
            public void Visit(Environment that);
            public void Visit(DataSpecification that);
        }  // public interface IVisitor

        /// <summary>
        /// Define the interface for a visitor which visits the instances of the model.
        /// </summary>
        /// <typeparam name="C">Context type</typeparam>
        public interface IVisitorWithContext<C>
        {
            public void Visit(IClass that, C context);
            public void Visit(Resource that, C context);
            public void Visit(Qualifier that, C context);
            public void Visit(ReferenceElement that, C context);
            public void Visit(GlobalReference that, C context);
            public void Visit(ModelReference that, C context);
            public void Visit(Key that, C context);
            public void Visit(Extension that, C context);
            public void Visit(AdministrativeInformation that, C context);
            public void Visit(AssetAdministrationShell that, C context);
            public void Visit(AssetInformation that, C context);
            public void Visit(IdentifierKeyValuePair that, C context);
            public void Visit(Submodel that, C context);
            public void Visit(SubmodelElementList that, C context);
            public void Visit(SubmodelElementStruct that, C context);
            public void Visit(Property that, C context);
            public void Visit(MultiLanguageProperty that, C context);
            public void Visit(Range that, C context);
            public void Visit(Blob that, C context);
            public void Visit(File that, C context);
            public void Visit(AnnotatedRelationshipElement that, C context);
            public void Visit(BasicEventElement that, C context);
            public void Visit(EventPayload that, C context);
            public void Visit(Entity that, C context);
            public void Visit(BasicEvent that, C context);
            public void Visit(Operation that, C context);
            public void Visit(OperationVariable that, C context);
            public void Visit(Capability that, C context);
            public void Visit(ConceptDescription that, C context);
            public void Visit(View that, C context);
            public void Visit(ValueReferencePair that, C context);
            public void Visit(ValueList that, C context);
            public void Visit(DataSpecificationIec61360 that, C context);
            public void Visit(DataSpecificationPhysicalUnit that, C context);
            public void Visit(Environment that, C context);
            public void Visit(DataSpecification that, C context);
        }  // public interface IVisitorWithContext

        /// <summary>
        /// Define the interface for a transformer which transforms recursively
        /// the instances into something else.
        /// </summary>
        /// <typeparam name="T">The type of the transformation result</typeparam>
        public interface ITransformer<T>
        {
            public T Transform(IClass that);
            public T Transform(Resource that);
            public T Transform(Qualifier that);
            public T Transform(ReferenceElement that);
            public T Transform(GlobalReference that);
            public T Transform(ModelReference that);
            public T Transform(Key that);
            public T Transform(Extension that);
            public T Transform(AdministrativeInformation that);
            public T Transform(AssetAdministrationShell that);
            public T Transform(AssetInformation that);
            public T Transform(IdentifierKeyValuePair that);
            public T Transform(Submodel that);
            public T Transform(SubmodelElementList that);
            public T Transform(SubmodelElementStruct that);
            public T Transform(Property that);
            public T Transform(MultiLanguageProperty that);
            public T Transform(Range that);
            public T Transform(Blob that);
            public T Transform(File that);
            public T Transform(AnnotatedRelationshipElement that);
            public T Transform(BasicEventElement that);
            public T Transform(EventPayload that);
            public T Transform(Entity that);
            public T Transform(BasicEvent that);
            public T Transform(Operation that);
            public T Transform(OperationVariable that);
            public T Transform(Capability that);
            public T Transform(ConceptDescription that);
            public T Transform(View that);
            public T Transform(ValueReferencePair that);
            public T Transform(ValueList that);
            public T Transform(DataSpecificationIec61360 that);
            public T Transform(DataSpecificationPhysicalUnit that);
            public T Transform(Environment that);
            public T Transform(DataSpecification that);
        }  // public interface ITransformer

        /// <summary>
        /// Perform double-dispatch to transform recursively
        /// the instances into something else.
        /// </summary>
        /// <typeparam name="T">The type of the transformation result</typeparam>
        public abstract class AbstractTransformer<T> : ITransformer<T>
        {
            public T Transform(IClass that)
            {
                return that.Transform(this);
            }

            public abstract T Transform(Resource that);

            public abstract T Transform(Qualifier that);

            public abstract T Transform(ReferenceElement that);

            public abstract T Transform(GlobalReference that);

            public abstract T Transform(ModelReference that);

            public abstract T Transform(Key that);

            public abstract T Transform(Extension that);

            public abstract T Transform(AdministrativeInformation that);

            public abstract T Transform(AssetAdministrationShell that);

            public abstract T Transform(AssetInformation that);

            public abstract T Transform(IdentifierKeyValuePair that);

            public abstract T Transform(Submodel that);

            public abstract T Transform(SubmodelElementList that);

            public abstract T Transform(SubmodelElementStruct that);

            public abstract T Transform(Property that);

            public abstract T Transform(MultiLanguageProperty that);

            public abstract T Transform(Range that);

            public abstract T Transform(Blob that);

            public abstract T Transform(File that);

            public abstract T Transform(AnnotatedRelationshipElement that);

            public abstract T Transform(BasicEventElement that);

            public abstract T Transform(EventPayload that);

            public abstract T Transform(Entity that);

            public abstract T Transform(BasicEvent that);

            public abstract T Transform(Operation that);

            public abstract T Transform(OperationVariable that);

            public abstract T Transform(Capability that);

            public abstract T Transform(ConceptDescription that);

            public abstract T Transform(View that);

            public abstract T Transform(ValueReferencePair that);

            public abstract T Transform(ValueList that);

            public abstract T Transform(DataSpecificationIec61360 that);

            public abstract T Transform(DataSpecificationPhysicalUnit that);

            public abstract T Transform(Environment that);

            public abstract T Transform(DataSpecification that);
        }  // public abstract class AbstractTransformer

        /// <summary>
        /// Define the interface for a transformer which recursively transforms
        /// the instances into something else while the context is passed along.
        /// </summary>
        /// <typeparam name="C">Type of the transformation context</typeparam>
        /// <typeparam name="T">The type of the transformation result</typeparam>
        public interface ITransformerWithContext<C, T>
        {
            public T Transform(IClass that, C context);
            public T Transform(Resource that, C context);
            public T Transform(Qualifier that, C context);
            public T Transform(ReferenceElement that, C context);
            public T Transform(GlobalReference that, C context);
            public T Transform(ModelReference that, C context);
            public T Transform(Key that, C context);
            public T Transform(Extension that, C context);
            public T Transform(AdministrativeInformation that, C context);
            public T Transform(AssetAdministrationShell that, C context);
            public T Transform(AssetInformation that, C context);
            public T Transform(IdentifierKeyValuePair that, C context);
            public T Transform(Submodel that, C context);
            public T Transform(SubmodelElementList that, C context);
            public T Transform(SubmodelElementStruct that, C context);
            public T Transform(Property that, C context);
            public T Transform(MultiLanguageProperty that, C context);
            public T Transform(Range that, C context);
            public T Transform(Blob that, C context);
            public T Transform(File that, C context);
            public T Transform(AnnotatedRelationshipElement that, C context);
            public T Transform(BasicEventElement that, C context);
            public T Transform(EventPayload that, C context);
            public T Transform(Entity that, C context);
            public T Transform(BasicEvent that, C context);
            public T Transform(Operation that, C context);
            public T Transform(OperationVariable that, C context);
            public T Transform(Capability that, C context);
            public T Transform(ConceptDescription that, C context);
            public T Transform(View that, C context);
            public T Transform(ValueReferencePair that, C context);
            public T Transform(ValueList that, C context);
            public T Transform(DataSpecificationIec61360 that, C context);
            public T Transform(DataSpecificationPhysicalUnit that, C context);
            public T Transform(Environment that, C context);
            public T Transform(DataSpecification that, C context);
        }  // public interface ITransformerWithContext

        /// <summary>
        /// Perform double-dispatch to transform recursively
        /// the instances into something else.
        /// </summary>
        /// <typeparam name="C">The type of the transformation context</typeparam>
        /// <typeparam name="T">The type of the transformation result</typeparam>
        public abstract class AbstractTransformerWithContext<C, T>
            : ITransformerWithContext<C, T>
        {
            public T Transform(IClass that, C context)
            {
                return that.Transform(this, context);
            }

            public abstract T Transform(Resource that, C context);

            public abstract T Transform(Qualifier that, C context);

            public abstract T Transform(ReferenceElement that, C context);

            public abstract T Transform(GlobalReference that, C context);

            public abstract T Transform(ModelReference that, C context);

            public abstract T Transform(Key that, C context);

            public abstract T Transform(Extension that, C context);

            public abstract T Transform(AdministrativeInformation that, C context);

            public abstract T Transform(AssetAdministrationShell that, C context);

            public abstract T Transform(AssetInformation that, C context);

            public abstract T Transform(IdentifierKeyValuePair that, C context);

            public abstract T Transform(Submodel that, C context);

            public abstract T Transform(SubmodelElementList that, C context);

            public abstract T Transform(SubmodelElementStruct that, C context);

            public abstract T Transform(Property that, C context);

            public abstract T Transform(MultiLanguageProperty that, C context);

            public abstract T Transform(Range that, C context);

            public abstract T Transform(Blob that, C context);

            public abstract T Transform(File that, C context);

            public abstract T Transform(AnnotatedRelationshipElement that, C context);

            public abstract T Transform(BasicEventElement that, C context);

            public abstract T Transform(EventPayload that, C context);

            public abstract T Transform(Entity that, C context);

            public abstract T Transform(BasicEvent that, C context);

            public abstract T Transform(Operation that, C context);

            public abstract T Transform(OperationVariable that, C context);

            public abstract T Transform(Capability that, C context);

            public abstract T Transform(ConceptDescription that, C context);

            public abstract T Transform(View that, C context);

            public abstract T Transform(ValueReferencePair that, C context);

            public abstract T Transform(ValueList that, C context);

            public abstract T Transform(DataSpecificationIec61360 that, C context);

            public abstract T Transform(DataSpecificationPhysicalUnit that, C context);

            public abstract T Transform(Environment that, C context);

            public abstract T Transform(DataSpecification that, C context);
        }  // public abstract class AbstractTransformerWithContext
    }  // public static class Visitation
}  // namespace AasCore.Aas3

/*
 * This code has been automatically generated by aas-core-codegen.
 * Do NOT edit or append.
 */
