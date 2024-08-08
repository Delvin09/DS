using DataStructers.Lib;
using DataStructers.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using System.Collections.Immutable;

namespace DataStructers.Test
{
    class FileLogger
    {
        public void SaveTestResult(object sender, EventArgs eventArgs)
        {

        }

        public void StartTestGroup(string testGroupName)
        {
        }
    }

    internal class Program
    {
        static void ProcessReports(IEnumerable<string> reports)
        {
            foreach (var item in reports)
            {
                Console.WriteLine(item);
            }


            var iterator = reports.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }

        static void Main(string[] args)
        {
            var us = new UniversityService();
            var students = us.GetStudentsWithoutMarks();
            var subjects = us.GetSubjectWithStudents();
            var marks = us.GetSubjectWithHightMarkStudent();

            us.GetAllStudentsWithCondition();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }


            var logger = new FileLogger();
            var renerer = new ConsoleTestRenderer();

            ITestGroup[] tests = { new ListTests(), new LinkedListTests() };

            foreach (var testGroup in tests)
            {
                //testGroup.Attach((ITestGroupStartObserver)logger);

                //testGroup.Attach((ITestGroupStartObserver)renerer);
                //testGroup.AddTestStart(renerer.RenderHeader);
                //testGroup.OnBeforeTestGroupRun += logger.StartTestGroup;
                testGroup.OnAfterTestRun += logger.SaveTestResult;

                testGroup.OnBeforeTestGroupRun += renerer.RenderHeader;
                testGroup.OnAfterTestRun += renerer.ShowTestResult;

                testGroup.Run();

                testGroup.OnAfterTestRun -= renerer.ShowTestResult;
                testGroup.OnBeforeTestGroupRun -= renerer.RenderHeader;
                //testGroup.Detach((ITestGroupStartObserver)renerer);
                //testGroup.RemoveTestStart(renerer.RenderHeader);
            }

            //OldTests.Run();
        }
    }
}
