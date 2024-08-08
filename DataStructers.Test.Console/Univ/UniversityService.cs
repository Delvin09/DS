using System.Globalization;

namespace DataStructers.Test
{
    class UniversityService
    {
        System.Collections.Generic.List<Person> persons = new System.Collections.Generic.List<Person>()
            {
                new Student { Name = "Sam", Age = 18, StudyYear = 1, Faculty = "Когтедран", Subjects = ["Как не задушить Python"] },
                new Student { Name = "Sara", Age = 20, StudyYear = 3, Faculty = "Облизерин", Subjects = ["Как не задушить Python"] },
                new Student { Name = "Sara2", Age = 19, StudyYear = 2, Faculty = "Вуснедуй", Subjects = ["Узнать JavaScript и не умереть"] },
                new Student { Name = "Bill", Age = 18, StudyYear = 1, Faculty = "Облизерин", Subjects = [ "Как не задушить Python"] },
                new Student { Name = "Tedd", Age = 22, StudyYear = 5, Faculty = "Когтедран", Subjects = ["С++ без насилия", "Пределы совершенства с C#"] },
                new Student { Name = "Jon", Age = 21, StudyYear = 4, Faculty = "Вуснедуй", Subjects = ["Пределы совершенства с C#" ] },
                new Student { Name = "Harry", Age = 22, StudyYear = 5, Faculty = "Когтедран", Subjects = ["Пределы совершенства с C#"] },
                new Student { Name = "Fred", Age = 19, StudyYear = 2, Faculty = "Вуснедуй", Subjects = ["С++ без насилия"] },
                new Student { Name = "Jane", Age = 20, StudyYear = 3, Faculty = "Облизерин", Subjects = ["С++ без насилия"] },
                new Student { Name = "Lucia", Age = 21, StudyYear = 2, Faculty = "Когтедран", Subjects = ["С++ без насилия" ] },
                new Student { Name = "Julia", Age = 20, StudyYear = 1, Faculty = "Вуснедуй", Subjects = ["VisualBasic как эталон технологий древних"] },
                new Student { Name = "Donna", Age = 19, StudyYear = 2, Faculty = "Облизерин", Subjects = ["С++ без насилия" ] },

                new Teacher { Name = "Quandala Sausage", Age = 53, SubjectName = "С++ без насилия" },
                new Teacher { Name = "Ramrod", Age = 55, SubjectName = "Как не задушить Python" },
                new Teacher { Name = "Gingerbread", Age = 49, SubjectName = "Пределы совершенства с C#" },
                new Teacher { Name = "Jinglebop Bittle", Age = 46, SubjectName = "Узнать JavaScript и не умереть" },
                new Teacher { Name = "Munchkin Toffeeson", Age = 60, SubjectName = "VisualBasic как эталон технологий древних" },
            };

        System.Collections.Generic.List<Faculty> faculties = new System.Collections.Generic.List<Faculty>()
            {
                new Faculty { Name = "Когтедран", DeanName = "Quandala Sausage" },
                new Faculty { Name = "Облизерин", DeanName = "Ramrod" },
                new Faculty { Name = "Вуснедуй", DeanName = "Jinglebop Bittle" },
            };

        System.Collections.Generic.List<Subject> subjects = new System.Collections.Generic.List<Subject>()
            {
                new Subject { Name = "С++ без насилия" },
                new Subject { Name = "Как не задушить Python" },
                new Subject { Name = "Пределы совершенства с C#" },
                new Subject { Name = "Узнать JavaScript и не умереть" },
                new Subject { Name = "VisualBasic как эталон технологий древних" },
            };

        System.Collections.Generic.List<Rating> ratings = new System.Collections.Generic.List<Rating>()
        {
            new Rating{ Mark = 3, Student = "Lucia", Subject = "С++ без насилия" },
            new Rating{ Mark = 2, Student = "Lucia", Subject = "С++ без насилия" },
            new Rating{ Mark = 4, Student = "Lucia", Subject = "С++ без насилия" },
            new Rating{ Mark = 2, Student = "Lucia", Subject = "С++ без насилия" },

            new Rating{ Mark = 4, Student = "Donna", Subject = "С++ без насилия" },
            new Rating{ Mark = 4, Student = "Donna", Subject = "С++ без насилия" },
            new Rating{ Mark = 5, Student = "Donna", Subject = "С++ без насилия" },
            new Rating{ Mark = 2, Student = "Donna", Subject = "С++ без насилия" },

            new Rating{ Mark = 2, Student = "Tedd", Subject = "С++ без насилия" },
            new Rating{ Mark = 2, Student = "Tedd", Subject = "С++ без насилия" },
            new Rating{ Mark = 3, Student = "Tedd", Subject = "С++ без насилия" },
            new Rating{ Mark = 2, Student = "Tedd", Subject = "С++ без насилия" },

            new Rating{ Mark = 5, Student = "Jane", Subject = "С++ без насилия" },
            new Rating{ Mark = 5, Student = "Jane", Subject = "С++ без насилия" },
            new Rating{ Mark = 3, Student = "Jane", Subject = "С++ без насилия" },
            new Rating{ Mark = 4, Student = "Jane", Subject = "С++ без насилия" },

            new Rating{ Mark = 4, Student = "Fred", Subject = "С++ без насилия" },
            new Rating{ Mark = 4, Student = "Fred", Subject = "С++ без насилия" },
            new Rating{ Mark = 5, Student = "Fred", Subject = "С++ без насилия" },
            new Rating{ Mark = 4, Student = "Fred", Subject = "С++ без насилия" },

            new Rating{ Mark = 2, Student = "Sam", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 2, Student = "Sam", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 3, Student = "Sam", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 2, Student = "Sam", Subject = "Как не задушить Python"  },

            new Rating{ Mark = 3, Student = "Sara", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 3, Student = "Sara", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 4, Student = "Sara", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 3, Student = "Sara", Subject = "Как не задушить Python"  },

            new Rating{ Mark = 2, Student = "Bill", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 3, Student = "Bill", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 3, Student = "Bill", Subject = "Как не задушить Python"  },
            new Rating{ Mark = 4, Student = "Bill", Subject = "Как не задушить Python"  },

            new Rating{ Mark = 2, Student = "Tedd", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Tedd", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Tedd", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 2, Student = "Tedd", Subject = "Пределы совершенства с C#"  },

            new Rating{ Mark = 5, Student = "Jon", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Jon", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 4, Student = "Jon", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Jon", Subject = "Пределы совершенства с C#"  },

            new Rating{ Mark = 1, Student = "Harry", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Harry", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 3, Student = "Harry", Subject = "Пределы совершенства с C#"  },
            new Rating{ Mark = 4, Student = "Harry", Subject = "Пределы совершенства с C#"  },

            new Rating{ Mark = 2, Student = "Julia", Subject = "VisualBasic как эталон технологий древних"  },
            new Rating{ Mark = 5, Student = "Julia", Subject = "VisualBasic как эталон технологий древних"  },
            new Rating{ Mark = 2, Student = "Julia", Subject = "VisualBasic как эталон технологий древних"  },
            new Rating{ Mark = 5, Student = "Julia", Subject = "VisualBasic как эталон технологий древних"  },
        };


        // 1. Студенты и преп. которые не имеют занятий
        // 2. Топ студентов по успеваемости - сред. оценка по предмету - и среднее по всем предметам
        // 3. Топ 3 стд для каждого предмета.
        // 4. Все студенты каждого преподователя.
        // 5. Студенты факультета которые посещают одни предметы.
        // 6. Студенты у которых нет оценок по предметам, со списком предметов

        class RatingMultiKey
        {
            public string StudentName { get; set; }
            public string Subject { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj == null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;

                var other = (RatingMultiKey)obj;
                return StudentName == other.StudentName && Subject == other.Subject;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(StudentName, Subject);
            }
        }

        public void GetAllStudentsWithCondition()
        {
            var query = from student in persons.OfType<Student>()
                        orderby student.Name, student.StudyYear descending
                        select student;

            query.ToList();
        }


        public Dictionary<string, Student[]> GetSubjectWithHightMarkStudent()
        {
            var r = ratings
                .GroupBy(
                    r => new RatingMultiKey { Subject = r.Subject, StudentName = r.Student },
                    (key, ranks) => new { key.Subject, key.StudentName, AvgRank = ranks.Average(r => r.Mark) })
                .GroupBy(r => r.Subject, (k, v) => new { Subject = k, TopStudent = v.MaxBy(s => s.AvgRank) })
                .ToList();


            //var r = persons.OfType<Student>()
            //    .SelectMany(s => s.Subjects, (st, sb) => new { Student = st, Subject = sb })
            //    .GroupBy(s => s.Subject)
            //    .Join(
            //        ratings,
            //        k => k. )

            //    .ToDictionary(k => k.Key, v => v.ToArray());
            //return r;
            return null;
        }

        public Dictionary<string, Student[]> GetSubjectWithStudents()
        {
            var r = persons.OfType<Student>()
                .SelectMany(s => s.Subjects, (st, sb) => new { Student = st, Subject = sb })
                .GroupBy(s => s.Subject, s => s.Student)
                .ToDictionary(k => k.Key, v => v.ToArray());
            return r;
        }

        public IEnumerable<StudentView> GetStudentsWithoutMarks()
        {
            //var r = persons.OfType<Student>()
            //    .Join(faculties,
            //        st => st.Faculty,
            //        f => f.Name,
            //        (st, f) => new { Student = st, Dean = f.DeanName })
            //    ;

            //foreach (var s in r)
            //{
            //    Console.WriteLine($"{s.Student.Name} {s.Dean}");
            //}

            var r = persons.OfType<Student>()
                .SelectMany(s => s.Subjects, (st, sb) => new { Student = st, Subject = sb })
                .Join(ratings,
                    st => st.Subject,
                    r => r.Subject,
                    (st, r) => r
                )
                .OrderBy(s => s.Student)
                    .ThenBy(s => s.Subject)
                    .ThenBy(s => s.Mark);

            return persons.OfType<Student>()
                .SelectMany(s => s.Subjects, (st, sb) => new { Student = st, Subject = sb })
                .Where(s => !ratings.Any(r => r.Subject == s.Subject))
                .Select(s => new StudentView { Name = s.Student.Name, Subject = s.Subject, Faculty = s.Student.Faculty });
        }
    }


    class StudentView
    {
        public string Name { get; set; }

        public string Faculty { get; set; }

        public string Subject { get; set; }

        public override string ToString()
        {
            return $"{Name} {Faculty} {Subject}";
        }
    }
}
