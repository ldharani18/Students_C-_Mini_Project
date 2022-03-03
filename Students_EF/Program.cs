using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_MP
{
    //declaring a delegate with string as a parameter
    public delegate void PrintWelcome(string msg);
    public class Program
    {
        public static void Main(string[]args)
        {
            List<SchoolStudent> Li_school_stud = new List<SchoolStudent>()
            {
                new SchoolStudent(){Roll_No = 1,F_Name="Albert",L_Name="Einstein",DOB=new DateTime(2000,01,02),Age=21,Address="A Street",Class_and_Section="X-A",Average_Mark=98.8,Rank_No=1},
                new SchoolStudent(){Roll_No = 2,F_Name="Bill",L_Name="Gates",DOB=new DateTime(1999,08,22),Age=22,Address="B Street",Class_and_Section="X-B",Average_Mark=80,Rank_No=3},
                new SchoolStudent(){Roll_No = 3,F_Name="Charles",L_Name="Babbage",DOB=new DateTime(2000,11,09),Age=21,Address="C Street",Class_and_Section="X-A",Average_Mark=78.9,Rank_No=4},
                new SchoolStudent(){Roll_No = 4,F_Name="Darwin",L_Name="Finch",DOB=new DateTime(2000,07,30),Age=21,Address="D Street",Class_and_Section="X-B",Average_Mark=69.8,Rank_No=6},
                new SchoolStudent(){Roll_No = 5,F_Name="Elizabeth",L_Name="Queen",DOB=new DateTime(1999,05,10),Age=22,Address="E Street",Class_and_Section="X-B",Average_Mark=90,Rank_No=2},
                new SchoolStudent(){Roll_No = 6,F_Name="Filthy",L_Name="Rich",DOB=new DateTime(2000,01,01),Age=21,Address="F Street",Class_and_Section="X-A",Average_Mark=76.3,Rank_No=5},

            };

            //creating a list of college students
            List<CollegeStudent> Li_college_stud = new List<CollegeStudent>()
            {
                //using enumeration to assign roll_no to collegestudents.
                new CollegeStudent(){Roll_No = (int)Id_enum.one,F_Name="A_Stud",L_Name="Name_A",DOB=new DateTime(2000,01,02),Age=21,Address="A Street",Class_and_Section="ECE-A",MobileNo=8676755645,Mail_Id="namea@gmail.com",Dept="ECE",X_mark=465,XII_mark=1154,CGPA=9.3,Year="I"},
                new CollegeStudent(){Roll_No = (int)Id_enum.two,F_Name="B_Stud",L_Name="Name_B",DOB=new DateTime(1999,08,22),Age=22,Address="B Street",Class_and_Section="ECE-B",MobileNo=8676989645,Mail_Id="nameb@gmail.com",Dept="ECE",X_mark=490,XII_mark=1001,CGPA=8.6,Year="II"},
                new CollegeStudent(){Roll_No = (int)Id_enum.three,F_Name="C_Stud",L_Name="Name_C",DOB=new DateTime(2000,11,09),Age=21,Address="C Street",Class_and_Section="EEE-A",MobileNo=9076755645,Mail_Id="namec@gmail.com",Dept="EEE",X_mark=423,XII_mark=1091,CGPA=8.0,Year="I"},
                new CollegeStudent(){Roll_No = (int)Id_enum.four,F_Name="D_Stud",L_Name="Name_D",DOB=new DateTime(2000,07,30),Age=21,Address="D Street",Class_and_Section="MECH-B",MobileNo=8612435645,Mail_Id="named@gmail.com",Dept="MECH",X_mark=397,XII_mark=998,CGPA=7.5,Year="I"},
                new CollegeStudent(){Roll_No = (int)Id_enum.five,F_Name="E_Stud",L_Name="Name_E",DOB=new DateTime(1999,05,10),Age=22,Address="E Street",Class_and_Section="CIVIL-B",MobileNo=9978755645,Mail_Id="namee@gmail.com",Dept="CIVIL",X_mark=496,XII_mark=1101,CGPA=9.4,Year="III"},
                new CollegeStudent(){Roll_No = (int)Id_enum.six,F_Name="F_Stud",L_Name="Name_F",DOB=new DateTime(2000,01,01),Age=21,Address="F Street",Class_and_Section="CSE-A",MobileNo=6854365645,Mail_Id="namef@gmail.com",Dept="CSE",X_mark=409,XII_mark=876,CGPA=9.02,Year="IV"},

            };


            //Getting input from user to perform add,delete or display operation from schoolstudent list
            Console.WriteLine("Enter the operation to be done:");
            Console.WriteLine("1.Add an entry of a student\n2.Remove an entry of a student\n3.Display an entry of a student");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the roll_no,F_name,L_Name,address and age of the student whose entries are to be added:");
                        int roll_no;
                        while (true)
                        {
                            roll_no = Convert.ToInt32(Console.ReadLine());
                            //LINQ Query Syntax
                            var result = from s in Li_school_stud
                                         where s.Roll_No == roll_no
                                         select s;

                            //LINQ Method Syntax
                            //var result = Li_school_stud.Where(s=>s.Roll_No==roll_no);
                            int c = result.Count();
                            if (c > 0)
                            {
                                Console.WriteLine("ID should be unique.So enter another id.");
                                continue;
                            }
                            else
                                break;

                        }
                        string F_name = Console.ReadLine();
                        string L_name = Console.ReadLine();
                        string address = Console.ReadLine();
                        int age = Convert.ToInt32(Console.ReadLine());
                        //Adding an entry to Schoolstudent list
                        Li_school_stud.Add(new SchoolStudent() { Roll_No = roll_no, F_Name = F_name, L_Name = L_name, Address = address, Age = age });
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter the name of the student whose entries are to be deleted");
                        string name = Console.ReadLine();
                        //Finding index of element whose name matches with entry
                        int ind = Li_school_stud.FindIndex(ch => ch.F_Name == name);

                        bool flag = Li_school_stud.Any(s => s.F_Name == name);//checks whether there is any firstname equal to the input name

                        //Checking whether the entered student name is contained in the list or not.
                        if (flag == false)
                            Console.WriteLine("The entry of the student named " + name + " was not available.");
                        else
                            Li_school_stud.RemoveAt(ind);//removes an entry present at a particular index

                        //var r = from ss in Li_school_stud
                        //        where ss.F_Name == name
                        //        select Li_school_stud.IndexOf(ss);
                        //Li_school_stud.RemoveAll(s => s.F_Name == name);//---removes an entry of school student whose name matches with the input.

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter the roll_no of the student whose details are to be fetched");
                        int roll_no = Convert.ToInt32(Console.ReadLine());
                        var result = from s in Li_school_stud
                                     where s.Roll_No == roll_no
                                     select s;
                        foreach (var s in result)
                        {
                            Console.WriteLine("Roll No: " + s.Roll_No + "\nF_Name: " + s.F_Name + "\nL_Name: " + s.L_Name + "\nDOB: " + s.DOB + "\nAge: " + s.Age + "\nAddress: " + s.Address + "\nClass_and_Section: " + s.Class_and_Section + "\nAverage Mark: " + s.Average_Mark + "\nRank_Number: " + s.Rank_No);
                        }
                        //Checking whether the entered roll_no is available in the studentlist or not
                        if (result.Count() == 0)
                            Console.WriteLine("The roll_no you have entered is not available.");
                        break;
                    }
                default:
                    break;
            }

            Console.WriteLine();

            //creating object for Student_Operations to perform write/read operation
            FileWrite_Read operations = new Student();

            //writing the contents of schoolstudent list into School_File
            operations.WriteToBinaryFile(@"E:\Desktop_Files\work_log\School_File.txt", Li_school_stud);

            //writing the content of collegestudent list into College_File
            operations.WriteToBinaryFile(@"E:\Desktop_Files\work_log\College_File.txt", Li_college_stud);

            //reading the contents present in School_File
            List<SchoolStudent> read_school = operations.ReadFromBinaryFile<SchoolStudent>(@"E:\Desktop_Files\work_log\School_File.txt");

            //reading the contents present in College_File
            List<CollegeStudent> read_college = operations.ReadFromBinaryFile<CollegeStudent>(@"E:\Desktop_Files\work_log\College_File.txt");

            //Displaying the read content from School_File
            Console.WriteLine("\nThe entries of school students are:\n");
            //Printing each entry of school student using Linq query
            read_school.ForEach(ss =>
            {
                Console.WriteLine($"{ss.Roll_No} {ss.F_Name} {ss.L_Name} {ss.DOB} {ss.Age} {ss.Address} {ss.Class_and_Section} {ss.Average_Mark} {ss.Rank_No}");
            }
            );

            //Displaying the read content from College_File
            Console.WriteLine("\nThe entries of college students are:\n");
            foreach (CollegeStudent cs in read_college)
            {
                //used string interpolation to print elements
                Console.WriteLine($"{cs.Roll_No} {cs.F_Name} {cs.L_Name} {cs.DOB} {cs.Age} {cs.Address} {cs.Class_and_Section} {cs.MobileNo} {cs.Mail_Id} {cs.Dept} {cs.X_mark} {cs.XII_mark} {cs.CGPA} {cs.Year}");
            }

            Console.WriteLine("\nThe Student who secured Ist Rank is ");
            read_school.ForEach(stud => {
                if (stud.Rank_No == 1)
                    Console.WriteLine(stud.F_Name + " " + stud.L_Name);
                //prints the name of the student who secured 1st rank
            });
            //Normal max function is used to return a maximum value of an element
            var maxcgpa = read_college.Max(std => std.CGPA);
            Console.WriteLine(maxcgpa + "\n");

            //Max() uses IComparable<CollegeStudent> to compare and find a student with maximum CGPA
            Console.WriteLine("\nThe Student with highest CGPA is ");
            var maxcgpastudent = read_college.Max();
            Console.WriteLine(maxcgpastudent.F_Name + " " + maxcgpastudent.L_Name + "\n");


            Console.WriteLine("Names of school student whose name starts with C are:");
            var namewithstartC = read_school.Where(student => student.F_Name.StartsWith("C"));
            //Startswith function helps to find names with starting letter.
            foreach (var tempname in namewithstartC)
            {
                Console.WriteLine(tempname.F_Name);
            }

            //Displaying the hobbies of students
            Hobby hobby = new Student();
            Console.WriteLine("\nHobbies of students are: ");
            hobby.Singing();
            hobby.Dancing();
            hobby.Yoga();

            //Using delegates to print a welcome message
            PrintWelcome pw;
            pw = (string msg) => Console.WriteLine(msg);
            pw("\nWelcome to C#");

            Console.Read();

        }
    }
    enum Id_enum
    {
        one = 1,
        two,
        three,
        four,
        five,
        six
    }
}
