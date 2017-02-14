// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SFA.DAS.RAA.Api.Client.V1.Models
{
    using System.Linq;

    public partial class Category
    {
        /// <summary>
        /// Initializes a new instance of the Category class.
        /// </summary>
        public Category() { }

        /// <summary>
        /// Initializes a new instance of the Category class.
        /// </summary>
        /// <param name="categoryType">Possible values include:
        /// 'SectorSubjectAreaTier1', 'Framework', 'StandardSector',
        /// 'Standard', 'Combined'</param>
        /// <param name="status">Possible values include: 'Active', 'Ceased',
        /// 'PendingClosure'</param>
        public Category(int id, string fullName, string codeName, string categoryType, string status, string parentCategoryCodeName = default(string), System.Collections.Generic.IList<Category> subCategories = default(System.Collections.Generic.IList<Category>))
        {
            Id = id;
            FullName = fullName;
            CodeName = codeName;
            ParentCategoryCodeName = parentCategoryCodeName;
            CategoryType = categoryType;
            Status = status;
            SubCategories = subCategories;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "CodeName")]
        public string CodeName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ParentCategoryCodeName")]
        public string ParentCategoryCodeName { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'SectorSubjectAreaTier1',
        /// 'Framework', 'StandardSector', 'Standard', 'Combined'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "CategoryType")]
        public string CategoryType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Active', 'Ceased',
        /// 'PendingClosure'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "SubCategories")]
        public System.Collections.Generic.IList<Category> SubCategories { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (FullName == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "FullName");
            }
            if (CodeName == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "CodeName");
            }
            if (CategoryType == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "CategoryType");
            }
            if (Status == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Status");
            }
            if (this.SubCategories != null)
            {
                foreach (var element in this.SubCategories)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}