﻿namespace DAL.Entities
{
    public class Answer
    {
        public virtual int Id { get; set; }
        public virtual string Value { get; set; }
        public virtual Test Test { get; set; }
    }
}
