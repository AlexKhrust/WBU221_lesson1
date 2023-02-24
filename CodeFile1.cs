using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; //для работы операторов ввода и вывода

namespace WTU221_lesson1
{
    internal class Program
    {
        static void startQuiz()
        {
            string[] questions =
                {"Самая высокая гора?",
                "Самая длинная река?",
                "Самая большая страна?"
                };

            string[] answers ={"эверест", "амазонка", "россия"};
            string[] answers2 = { "чогори", "нил", "китай" };   //мои доп. ответы
            string[] estimation = { "неудовлетворительно", "удовлетворительно", "хорошо" };   //мои оценки результата
            int countOfrightAnswers = 0;
            string userAnswer;

            for(int i= 0; i < questions.Length; i++)
            { 

            Write(questions[i]);
            userAnswer = ReadLine();

            if (userAnswer.ToLower() == answers[i])
            {
                countOfrightAnswers++;
                WriteLine("Ответ верный!");
            }
            else
            {
                    if (userAnswer.ToLower() == answers2[i]) //проверка на доп. ответы
                    {
                        WriteLine("Ответ неверный, но подскажу - ты вспомнил то, что стоит на втором месте!");
                    } 
                    WriteLine("Ответ неверный!");
            }
            }
            /*конструкция ниже как раз для выдачи оценки, сделана попытка в универсальность, т.е. если увеличить
             количество вопросов и ответов то оценочный код переделывать не нужно.*/

            if (countOfrightAnswers <= (questions.Length / 3)) //оценка неуд. если правильных ответов меньше либо равно трети вопросов

            {
                WriteLine("Правильных ответов: " + countOfrightAnswers + ". Твоя оценка - " + estimation[0]);
            }
            else 
            {
                if (countOfrightAnswers > (questions.Length / 3) && countOfrightAnswers <= (questions.Length/3 * 2)) //оценка уд. если правильных ответов больше трети и меньше либо равно двух третей вопросов
                { 
                    WriteLine("Правильных ответов: " + countOfrightAnswers + ". Твоя оценка - " + estimation[1]);
                }
                else { WriteLine("Правильных ответов: " + countOfrightAnswers + ". Твоя оценка - " + estimation[2]); }//оценка хорошо, только если все ответы верны, я так решил.
            }

            /*Предложение о повторной игре в Викторину. Хотел через тернарный, но не заладилось, поэтому нагромоздил. НО оно работает :)) */
            WriteLine("Не хочешь ещё раз сыграть? Y/N");
            string choice=ReadLine();
            if (choice.ToUpper() == "Y")
            { 
                startQuiz(); 
            }
            else
            {
                WriteLine("Ну не хочешь, как хочешь. Давай до свидания.");
            }
            
        }

        static void quessNamber()
        {
            WriteLine("*****Угадай число от 0 до 100!*****");
            Random rand = new Random(); //создаем объект 
            int magicNumber = rand.Next(0, 100);
            int userNumber = 0;
            int count = 0;
            int limit = 3; //Здесь задаем количество попыток
           
            /*Заменил цикл с do-while на for, так как нам больше не требуется вечный цикл.
             А требуется строгий лимит попыток*/

            for (int i=1; i<=limit; i++)
            {
                WriteLine("Введи число: ");
                int userNamber = Int32.Parse(ReadLine());
                count++;
                if (userNamber<magicNumber)
                {
                    WriteLine("Введенное число меньше загаданного");
                    WriteLine($"Попыток осталось = {limit-count}");
                }
                else if (userNamber > magicNumber)
                {
                    WriteLine("Введенное число больше загаданного");
                    WriteLine($"Попыток осталось = {limit - count}");
                }
                else if (userNamber == magicNumber)
                {
                    WriteLine("Верно! Загаданное число " + magicNumber);
                    WriteLine($"Тебе понадобилось {count} попыток"); //интерполированная строка Не конкатенация
                    break;
                }
            }
            WriteLine("Ты потратил все попытки впустую.");

            /*Предложение о повторной игре в Числа. Да продублировал с викторины */
            WriteLine("Не хочешь ещё раз сыграть? Y/N");
            string choice = ReadLine();
            if (choice.ToUpper() == "Y")
            {
                quessNamber();
            }
            else
            {
                WriteLine("Ну не хочешь, как хочешь. Давай до свидания.");
            }

        }
                
        static void Main(string[] args)
        {
            WriteLine("Для выбора игры введите следующие числа: 1 - Викторина / 2 - Числа / 0 - Выход из игры");
            string choice = ReadLine();

            switch (choice)
            {
                case "1":
                    startQuiz();
                    break;
                case "2":
                    quessNamber();
                    break;
                case"0":
                    break;
                
                default:
                    WriteLine("Нефиг писать всякую белиберду!");
                    break;
            }
        }
    }
}
