namespace DataStructers.Test
{
    class Faculty
    {
        public string Name { get; set; }
        public Teacher Dean { get; set; }
        public Student[] Students { get; set; }
        public string DeanName { get; internal set; }
    }
}
