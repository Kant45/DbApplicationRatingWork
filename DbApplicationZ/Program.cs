using System;

namespace DbApplicationZ {
    class Program {
        static void Main(string[] args) {

            while(true) {

                using(PracticeContext db = new PracticeContext()) {

                    Console.Write("Введите 1, если хотите добавить преподавателя или 2, если хотите добавить занятие ");
                    int n = 16;
                    int i = int.Parse(Console.ReadLine());

                    if(i == 1) {

                        Console.Write("Введите табельный номер: ");
                        string PersonnelNumber = Console.ReadLine();
                        Console.Write("Введите ФИО преподавателя: ");
                        string Name = Console.ReadLine();
                        Console.Write("Введите должность: ");
                        string Job = Console.ReadLine();

                        Преподаватели obj = new Преподаватели {

                            ТабельныйНомер = PersonnelNumber,
                            ФиоПреподавателя = Name,
                            Должность = Job
                        };

                        db.Преподавателиs.Add(obj);
                        db.SaveChanges();

                    } else {

                        Console.Write("Введите дисциплину: ");
                        string discipline = Console.ReadLine();

                        Console.Write("Введите дату занятия: ");
                        DateTime dateTime = DateTime.Parse(Console.ReadLine());

                        Console.Write("Введите группу: ");
                        string group = Console.ReadLine();

                        Console.Write("Введите часовую ставку: ");
                        int hourlyRate = int.Parse(Console.ReadLine());

                        Console.Write("Введите кол-во часов");
                        int hourCount = int.Parse(Console.ReadLine());

                        Console.Write("Введите существующий табельный номер: ");
                        string personnelNumber = Console.ReadLine();

                        Занятия obj = new Занятия {
                            Дисциплина = discipline,
                            ДатаЗанятия = dateTime,
                            Группа = group,
                            ЧасоваяСтавка = hourlyRate,
                            КолВоЧас = hourCount,
                            ТабельныйНомер = personnelNumber
                        };

                        db.Занятияs.Add(obj);
                        db.SaveChanges();
                    }
                }

                Console.WriteLine("Если хотите прервать сеанс, нажмите 1, или любую другую клавишу, чтобы продолжить ");
                int j = int.Parse(Console.ReadLine());

                if(j == 1)
                    break;
            }
        }
    }
}
