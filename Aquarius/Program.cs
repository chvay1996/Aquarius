using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquarius
{
    class Program
    {
        static void Main ( string [] args )
        {
            Aquarium aquarium = new Aquarium ();
            aquarium.Work ( );
        }
    }

    class Aquarium
    {
        private List<Fish> _fish = new List<Fish> ();
        private bool _isWork = true;
        private int _maximumFishLife = 14;
        private int _maximumFish = 11;

        public Aquarium ( )
        {
            _fish.Add ( new Fish ( "Петушок", 5 ));
            _fish.Add ( new Fish ( "Скалярия", 3 ) );
            _fish.Add ( new Fish ( "Барбусы", 2 ) );
            _fish.Add ( new Fish ( "Данио", 6 ) );
            _fish.Add ( new Fish ( "Анциструс", 7 ) );
        }

        public void Work ( )
        {
                while ( _isWork == true )
                {
                DeleteFish ();
                ShowFish ();
                CycleOfLife ();

                    Console.Write ( $"\n\nВсе pыбки живут до {_maximumFishLife} месяцев." +
                        $"\nМаксимум {_maximumFish} рыбок может быть в аквариуме!" +
                        "\n1 - Достать рыбку." +
                        "\n2 - Запустить рыбку." +
                        "\n3 - Выход.\n\n\t\t" );

                    switch ( int.Parse ( Console.ReadLine () ) )
                    {
                        case 1:
                            ToTakeFish ();
                            break;
                        case 2:
                            PutTheFish ();
                            break;
                        case 3:
                            _isWork = false;
                            break;
                        default:
                            Console.WriteLine ( "Неверно указано значение!" );
                            break;
                    }
                    Console.ReadLine ();
                    Console.Clear ();

                }
        }

        private void DeleteFish ()
        {
            for ( int i = 0; i < _fish.Count; i++ )
            {
                if ( _fish [ i ].Life >= _maximumFishLife )
                {
                    Console.WriteLine ( $"Рыбка {_fish [ i ].Name} умерла от старости" );
                    _fish.Remove ( _fish [ i ] );
                }
            }
        }

        private void ShowFish ( )
        {
            if ( CopyFish ().Count > 0 )
            {
                Console.WriteLine ( "Ваши рыбки" );

                for ( int i = 0; i < CopyFish ().Count ; i++ )
                {
                    CopyFish () [ i ].ShowInfo ( i + 1 );
                }
            }
            else Console.WriteLine ( "У вас нет Рыбок в аквариуме!" );
        }

        private List<Fish> CopyFish ()
        {
            List<Fish> fish = _fish.ToList ();
            return fish;
        }

        private void PutTheFish ()
        {
            if ( _fish.Count <= _maximumFish )
            {
                bool isNumber;
                Console.Write ( "Введите название рыбы:\t" );
                string name = Console.ReadLine ();
                Console.Write ( "Введите сколько месяцев рыбе:\t" );
                string userInput = Console.ReadLine ();
                isNumber = int.TryParse ( userInput, out int age );

                if ( isNumber == false )
                {
                    Console.WriteLine ( "Не верный ввод" );
                }
                else if ( age >= _maximumFishLife )
                {
                    Console.WriteLine ( "Ваша рыба не подходит для нашего аквариума" );
                }
                else
                {
                    _fish.Add ( new Fish ( name, age ) );
                    Console.WriteLine ( "Рыба успешно дабавлена" );
                }
            }
            else
            {
                Console.WriteLine ("В аквариуме нет больше мест!");
            }
        }

        private void ToTakeFish ()
        {
            if ( _fish.Count > 0 )
            {
                int userInput;
                Console.Write ( "Введите номер рыбы, которую хотите достать из аквариума:\t" );
                userInput = int.Parse(Console.ReadLine ());

                    if ( userInput > _fish.Count )
                    {
                    Console.WriteLine ( "Такой рыбы в аквариуме нету" );
                    }
                    else
                    {
                    Console.WriteLine ( $"Рыбу успешно достали {CopyFish () [userInput].Name}" );
                    _fish.Remove ( _fish [ userInput - 1] );
                    }
            }
            else
            {
                Console.WriteLine ( "Рыб в аквариуме нету" );
            }
        }

        private void CycleOfLife ()
        {
            for ( int i = 0; i < _fish.Count; i++ )
            {
                _fish [ i ].CycleOfLife ();
            }
        }
    }

    class Fish
    {
        public Fish( string name, int life )
        {
            Life = life;
            Name = name;
        }

        public Fish () { }

        public int Life { get; private set; }
        public string Name { get; private set; }

        public void ShowInfo (int namberFish)
        {
            Console.WriteLine ($"{namberFish}) {Name}, возрост - {Life} месяцев");
        }

        public void CycleOfLife ()
        {
            Life++;
        }
    }
}
/*Задача:
Есть аквариум, в котором плавают рыбы. 
В этом аквариуме может быть максимум определенное кол-во рыб. 
Рыб можно добавить в аквариум или рыб можно достать из аквариума. 
  (программу делать в цикле для того, чтобы рыбы могли “жить”)
Все рыбы отображаются списком, у рыб также есть возраст. 
За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть. 
Рыб также вывести в консоль, чтобы можно было мониторить показатели.*/