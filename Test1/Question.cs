//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public int Id { get; set; }
        public string content { get; set; }
        public string bonus { get; set; }
        public int CourseId { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
