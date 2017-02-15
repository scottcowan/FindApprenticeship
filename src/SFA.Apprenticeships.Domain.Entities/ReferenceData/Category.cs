﻿namespace SFA.Apprenticeships.Domain.Entities.ReferenceData
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private Category()
        {

        }

        public Category(int id, string codeName, string fullName, string parentCategoryCodeName, CategoryType categoryType, CategoryStatus status, IList<Category> subCategories, long? count)
        {
            Id = id;
            CodeName = codeName;
            FullName = fullName;
            ParentCategoryCodeName = parentCategoryCodeName;
            CategoryType = categoryType;
            Status = status;
            SubCategories = subCategories ?? new List<Category>();
            Count = count ?? 0;
        }

        public Category(int id, string codeName, string fullName, CategoryType categoryType, CategoryStatus status) : this(id, codeName, fullName, null, categoryType, status, null, null)
        {

        }

        //TODO: This ctor is only used in unit tests. Consider removing it. Please, oh please: remove it.
        public Category(int id, string codeName, string fullName, CategoryType categoryType, CategoryStatus status, IList<Category> subCategories) : this(id, codeName, fullName, null, categoryType, status, subCategories, null)
        {

        }

        public Category(int id, string codeName, string fullName, string parentCategoryCodeName, CategoryType categoryType, CategoryStatus status) : this(id, codeName, fullName, parentCategoryCodeName, categoryType, status, null, null)
        {

        }

        public Category(int id, string codeName, string fullName, string parentCategoryCodeName, CategoryType categoryType, CategoryStatus status, IList<Category> subCategories) : this(id, codeName, fullName, parentCategoryCodeName, categoryType, status, subCategories, null)
        {

        }

        public Category(int id, string codeName, string fullName, CategoryType categoryType, CategoryStatus status, IList<Category> subCategories, long? count) : this(id, codeName, fullName, null, categoryType, status, subCategories, count)
        {

        }

        public Category(int id, string codeName, string fullName, string parentCategoryCodeName, CategoryType categoryType, CategoryStatus status, long? count) : this(id, codeName, fullName, parentCategoryCodeName, categoryType, status, null, count)
        {

        }

        /// <summary>
        /// Category's identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Category's fullname
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Category's Codename
        /// </summary>
        [Required]
        public string CodeName { get; set; }

        /// <summary>
        /// Parent CategoryCode Name of the category
        /// </summary>
        public string ParentCategoryCodeName { get; set; }

        /// <summary>
        /// The category type
        /// </summary>
        [Required]
        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// Status of the category
        /// </summary>
        [Required]
        public CategoryStatus Status { get; set; }

        /// <summary>
        /// Lists a list of frameworks
        /// </summary>
        public IList<Category> SubCategories { get; set; }

        [JsonIgnore]
        public long Count { get; set; }

        public static readonly Category UnknownSectorSubjectAreaTier1 = new Category
        {
            CodeName = CategoryPrefixes.GetSectorSubjectAreaTier1Code("UNKNOWN"),
            FullName = "Unknown Sector Subject Area Tier 1"
        };

        public static readonly Category InvalidSectorSubjectAreaTier1 = new Category
        {
            CodeName = CategoryPrefixes.GetSectorSubjectAreaTier1Code("INVALID"),
            FullName = "Invalid Sector Subject Area Tier 1"
        };

        public static readonly Category EmptySectorSubjectAreaTier1 = new Category();

        public static readonly Category UnknownFramework = new Category
        {
            CodeName = CategoryPrefixes.GetFrameworkCode("UNKNOWN"),
            FullName = "Unknown Framework"
        };

        public static readonly Category InvalidFramework = new Category
        {
            CodeName = CategoryPrefixes.GetFrameworkCode("INVALID"),
            FullName = "Invalid Framework"
        };

        public static readonly Category EmptyFramework = new Category();

        public static readonly Category UnknownStandardSector = new Category
        {
            CodeName = CategoryPrefixes.GetStandardSectorCode("UNKNOWN"),
            FullName = "Unknown Standard Sector"
        };

        public static readonly Category InvalidStandardSector = new Category
        {
            CodeName = CategoryPrefixes.GetStandardSectorCode("INVALID"),
            FullName = "Invalid Standard Sector"
        };

        public static readonly Category InvalidSector = new Category
        {
            CodeName = CategoryPrefixes.GetSectorCode("INVALID"),
            FullName = "Invalid Sector"
        };
    }
}
