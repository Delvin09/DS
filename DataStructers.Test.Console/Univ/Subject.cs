namespace DataStructers.Test
{
    class Subject
    {
        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public Student[] Students { get; set; }

        public System.Collections.Generic.List<Rating> RatingTable { get; set; } = new System.Collections.Generic.List<Rating>();
    }
}
