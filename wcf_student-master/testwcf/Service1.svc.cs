using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace testwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private StudentContext sc = new StudentContext();
        public void CreateStudent(Student s)
        {
            sc.students.Add(s);
            sc.SaveChanges();
        }

        public void DeleteStudent(string cin)
        {
            Student s = (from st in sc.students
                         where st.cin == cin
                         select st).First();
            sc.students.Remove(s);
            sc.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return sc.students.ToList<Student>();
        }

        public Student GetStudent(string cin)
        {
            IEnumerable<Student> stud = (from st in sc.students
                           where st.cin == cin
                           select st);


            if (stud.Count() != 0) {
                Student stu = (from st in sc.students
                               where st.cin == cin
                               select st).First();
                return stu;
            } 
            else return (Student)null;
        }

        public void UpdateStudent(Student s)
        {
            Student stu = (from st in sc.students
                         where st.cin == s.cin
                         select st).First();
            
            stu.email = s.email is null? stu.email:s.email;
            stu.fil = s.fil is null ? stu.fil:s.fil;
            stu.first_name = s.first_name is null ? stu.first_name:s.first_name;
            stu.last_name = s.last_name is null ? stu.last_name:s.last_name;
            stu.phone = s.phone is null ? stu.phone:s.phone;

            sc.SaveChanges();
        }

        public IEnumerable<String> GetFils() {
            IEnumerable<String> L = (from st in sc.students
                              select st.fil).Distinct();
            
            return L;
        }

        public IEnumerable<Student> GetStudentsByFil(string fil)
        {
            if(fil == "") return sc.students.ToList<Student>();

            IEnumerable<Student> L = (from st in sc.students
                                     where st.fil == fil
                                     select st);
            return L;
        }
    }
}
