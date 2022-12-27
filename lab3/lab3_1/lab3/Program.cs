using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace lab3
{
    class Program
    {
        

        public enum faculty
        {
            Лингвистика = 0,
            ФизТех = 1,
            БиоХим = 2,
            ПрогИнж = 3
        };

        public class student
        {
            string surname;
            string firstname;
            string secondname;
            int birthdate;
            string adress;
            string phone;
            faculty facult;
            int course;

            public student(string surn, string fn, string secn, string a, string p, int c)
            {
                surname = surn;
                firstname = fn;
                secondname = secn;
                adress = a;
                phone = p;
                course = c;
            }
            public int setBirthdate
            {
                set {
                    if (2022 - value < 120 && 2022 - value > 0)
                    {
                        birthdate = value;
                    }
                    else
                        throw new Exception("некоректный год рождения");
                }
            }

            public faculty setFaculty
            {
                set { facult = value; }
            }
            public faculty getFaculty()
            {
                return facult;
            }
            public string getSurname()
            {
                return surname;
            }
            public string getFirstname()
            {
                return firstname;
            }
            public string getSecondname()
            {
                return secondname;
            }
            public string getAdress()
            {
                return adress;
            }
            public int getBirthYear()
            {
                return birthdate; 
            }
            public int getCourse()
            {
                return course;
            }
            public string getPhone()
            {
                return phone;
            }
        }

        static public void program_start()
        {
            studentlist[0] = new student("примеров", "пример", "примерович", "юности, 13", "88005553535", 2);
            studentlist[0].setBirthdate = 2000;
            studentlist[0].setFaculty = faculty.Лингвистика;
        }

        static int main_menu()
        {
            Console.Clear();
            int choise;
            Console.WriteLine("Пожалуйста, выберите действие из предложенных: \n\n\t1. Вывести список всех студентов. \n\n\t2. Добавить студента в список. \n\n\t3. Вывести список студентов заданного факультета. \n\n\t4. Вывести списки студентов по курсам и факультетам. \n\n\t5. Списки студентов, родившихся после заданного года. \n\n\t6.Выйти из программы.");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choise))
                {
                    if (choise > 0 && choise < 7)
                    {
                        return choise;
                        break;
                    }
                    else Console.WriteLine("Пожалуйста, укажите номер из списка");
                }
                else Console.WriteLine("Пожалуйста, укажите число");
            }           


        }
        static void list_show()
        {
            Console.Clear();
            for(int i=0; i<numberofst; i++)
            {
                Console.WriteLine(string.Format("{5}. {0} {1} {2}, студент {3} курса факультета '{4}'", studentlist[i].getSurname(), studentlist[i].getFirstname(), studentlist[i].getSecondname(), studentlist[i].getCourse(), studentlist[i].getFaculty(),i+1));
            }
            Console.WriteLine("\n\n\n\tНажмите любую кнопку, для возврата в меню.");
            Console.ReadKey();
        }

        static public void list_add()
        {
            Console.Clear();
            Console.WriteLine("Укажите фамилию студента");
            string sur = Console.ReadLine();
            Console.WriteLine("Укажите имя студента");
            string fnam = Console.ReadLine();
            Console.WriteLine("Укажите отчество студента");
            string snam = Console.ReadLine();
            Console.WriteLine("Укажите год рождения студента");
            int bd;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out bd))
                    break;
                else Console.WriteLine("укажите год рождения числом");
            }
            Console.WriteLine("Укажите адресс студента");
            string adr = Console.ReadLine();
            Console.WriteLine("Укажите телефон студента");
            string phon = Console.ReadLine();
            Console.WriteLine("Укажите факультет студента:");
            for(int i =0; i<4; i++)
            {
                Console.WriteLine(string.Format("{1}. {0}",(faculty)i,i+1));
            }
            int fac;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out fac))
                {
                    if (fac > 0 && fac < 4)
                    {
                        break;
                    }
                    else Console.WriteLine("Укажите число из списка");
                }
                else Console.WriteLine("Укажите целое число");
            }
            Console.WriteLine("Укажите курс студента");
            int cou;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out cou))
                {
                    break;
                }
                else Console.Write("Укажите курс целым числом");

            }
            numberofst++;
            int temp = numberofst - 1;
            Array.Resize(ref studentlist, numberofst);
            studentlist[temp] = new student(sur, fnam, snam, adr, phon, cou);
            studentlist[temp].setFaculty = (faculty)fac;
            studentlist[temp].setBirthdate = bd;
            Console.WriteLine("Введённые данные: \n");
            Console.WriteLine(studentlist[temp].getSurname());
            Console.WriteLine(studentlist[temp].getFirstname());
            Console.WriteLine(studentlist[temp].getSecondname());
            Console.WriteLine(studentlist[temp].getBirthYear());
            Console.WriteLine(studentlist[temp].getAdress());
            Console.WriteLine(studentlist[temp].getPhone());
            Console.WriteLine(studentlist[temp].getFaculty());
            Console.WriteLine(studentlist[temp].getCourse());
            Console.ReadKey();



        }
        static void facult_list()
        {
            Console.Clear();
            Console.WriteLine("Укажите факультет");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(string.Format("{1}. {0}", (faculty)i, i + 1));
            }
            int fac;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out fac))
                {
                    if (fac > 0 && fac < 4)
                    {
                        break;
                    }
                    else Console.WriteLine("Укажите число из списка");
                }
                else Console.WriteLine("Укажите целое число");
            }
            int k=1;
            bool nal = false;
            for(int i = 0; i<numberofst; i++)
            {
                if((faculty)fac == studentlist[i].getFaculty())
                {
                    Console.WriteLine(string.Format("{5}. {0} {1} {2}, студент {3} курса факультета '{4}'", studentlist[i].getSurname(), studentlist[i].getFirstname(), studentlist[i].getSecondname(), studentlist[i].getCourse(), studentlist[i].getFaculty(), k));
                    k++;
                    nal = true;
                }
                
            }
            if (nal == false) Console.WriteLine("Нет записей о студентах с этого факультета");
            Console.WriteLine("\n\n\n\tДля возвата в меню нажмите любую конпку");
            Console.ReadKey();
        }
        static void fac_cou_list()
        {
            Console.Clear();
            //bool nal1 = false;
            //bool nal2 = false;
            //bool nal3 = false ;
            //bool nal4 = false;
            bool nal;
            Console.WriteLine("\n\nФакультет Лингвистики\n");
            nal = facult_vivod(1);
            if (nal == false) Console.WriteLine("нет записей о студентах этого факультета");
            Console.WriteLine("\n\nФакультет ФизикоТехнический\n");
            nal = facult_vivod(2);
            if (nal == false) Console.WriteLine("нет записей о студентах этого факультета");
            Console.WriteLine("\n\nФакультет Биологии и Химии\n");
            nal = facult_vivod(3);
            if (nal == false) Console.WriteLine("нет записей о студентах этого факультета");
            Console.WriteLine("\n\nФакультет Програмной инженерии\n");
            nal = facult_vivod(4);
            if (nal == false) Console.WriteLine("нет записей о студентах этого факультета");

            Console.WriteLine("\n\n\n\tДля выхода в меню нажмите любую кнопку.");
            Console.ReadKey();

        }
        static bool facult_vivod(int facnum)
        {
            bool nal=false;
            for (int i = 0; i < numberofst; i++)
            {
                //if (studentlist[i].getFaculty() == faculty.Лингвистика) nal1 = true;
                //if (studentlist[i].getFaculty() == faculty.ФизТех) nal2 = true;
                //if (studentlist[i].getFaculty() == faculty.БиоХим) nal3 = true;
                //if (studentlist[i].getFaculty() == faculty.ПрогИнж) nal4 = true;
                if (studentlist[i].getFaculty() == (faculty)facnum)
                {
                    Console.WriteLine(string.Format("{0} курс: {1} {2} {3}\n", studentlist[i].getCourse(), studentlist[i].getSurname(), studentlist[i].getFirstname(), studentlist[i].getSecondname()));
                    nal = true;
                }
                //if(nal==false)
                //{
                //    Console.WriteLine("Нет записей о студентах этого факультета\n");
                //}

            }
            return nal;
        }

        static void by_vivod()
        {
            bool nal = false;
            int temp;
            Console.WriteLine("Укажите год рождения");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    if (2022-temp > 0 && 2022 - temp < 120)
                    {
                        break;
                    }
                    else Console.WriteLine("Укажите адекватный год");
                }
                else Console.WriteLine("Укажите год целым числом");
            }
            for (int i = 0; i < numberofst; i++)
            {
                if (studentlist[i].getBirthYear()==temp)
                {
                    Console.WriteLine(string.Format("{5}. {0} {1} {2}, студент {3} курса факультета '{4}'", studentlist[i].getSurname(), studentlist[i].getFirstname(), studentlist[i].getSecondname(), studentlist[i].getCourse(), studentlist[i].getFaculty(), i + 1));
                    nal = true;
                }
            }
            if (nal == false) Console.WriteLine("Нет студентов заданного года рождения");
        }


        static int numberofst = 1;
        static student[] studentlist = new student[numberofst];
        private static void Main(string[] args)
        {
            program_start();
            int action;
            while(true)
            {
                action = main_menu();
                switch(action)
                {    
                    case 1:
                        {
                            list_show();
                            break;
                        }
                    case 2:
                        {
                            list_add();
                            break;
                        }
                    case 3:
                        {
                            facult_list();
                            break;
                        }
                    case 4:
                        {
                            fac_cou_list();
                            break;
                        }
                    case 5:
                        {
                            by_vivod();
                            break;
                        }
                    case 6:
                        {
                            throw new Exception("Выход из программы");
                        }
                }
                   
            }
        
        
        }       
        
    }
}