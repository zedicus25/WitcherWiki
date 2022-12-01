namespace WitcherWikiAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Character
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Chapert_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Sex { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Race { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Occupation { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Affiliation { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [StringLength(150, MinimumLength = 10)]
        public string Image_Url { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
