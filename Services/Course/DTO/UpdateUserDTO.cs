﻿using System.ComponentModel;

namespace Services.Course.DTO
{
    public class UpdateCourseDTO
    {
        public required int Id { get; set; }
        [DefaultValue("Desenvolvido Web")]
        public required string Name { get; set; }
        [DefaultValue(true)]
        public required bool IsPublished { get; set; } = false;
        [DefaultValue("https://roimine.com/wp-content/uploads/2021/06/Confira-a-importancia-de-ter-um-site-otimizado-para-mobile.jpg")]
        public string? TumbnailUrl { get; set; }
        [DefaultValue("Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum , comes from a line in section 1.10.32.")]
        public required string Description { get; set; }
    }
}
