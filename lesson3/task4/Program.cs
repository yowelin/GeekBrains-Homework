using System;
using System.Collections.Generic;

namespace task4
{
    //Типы кораблей
    enum ShipType
    {
        OneDeck = 1, //Однопалубный
        TwoDeck = 2, //Двухпалубный
        ThreeDeck = 3, //Трехпалубный
        FourDeck = 4, //Четырехпалубный
    }
    //Расположение корабля
    enum Orientation
    {
        Horizontal = 1, //Горизонтально
        Vertical = 2, //Вертикально
    }
    //Корабль
    class Ship
    {
        public ShipType Type;
        public Orientation Orientation;
        //Получение количества кораблей
        public int GetQuantity()
        {
            int _quantity = 0;
            switch (Type)
            {
                case ShipType.OneDeck:
                    _quantity = 4;
                    break;
                case ShipType.TwoDeck:
                    _quantity = 3;
                    break;
                case ShipType.ThreeDeck:
                    _quantity = 2;
                    break;
                case ShipType.FourDeck:
                    _quantity = 1;
                    break;
            }
            return _quantity;
        }
        //Конструктор класса корабль
        public Ship(ShipType _type)
        {
            Type = _type;
        }
    }
    class availableCells
    {

    }
    class Program
    {
        static int[,] gamingTabel = new int[10, 10]; //Игровое поле
        //static bool isNull = true;

        static void Main(string[] args)
        {
            //Создаем четырехпалубный корабль
            Ship fourdeck = new Ship(ShipType.FourDeck);
            //Помещаем трехпалубный корабль в количестве 1
            PutShip(fourdeck, fourdeck.GetQuantity());
            //Создаем трехпалубный корабль
            Ship threedeck = new Ship(ShipType.ThreeDeck);
            //Помещаем трехпалубный корабль в количестве 2
            PutShip(threedeck, threedeck.GetQuantity());
            //Создаем двухпалубный корабль
            Ship twodeck = new Ship(ShipType.TwoDeck);
            //Помещаем двухпалубный корабль в количестве 3
            PutShip(twodeck, twodeck.GetQuantity());
            //Создаем однопалубный корабль
            Ship onedeck = new Ship(ShipType.OneDeck);
            //Помещаем однопалубный корабль в количестве 4
            PutShip(onedeck, onedeck.GetQuantity());
            /*if (isNull == true)
            {
                Console.WriteLine("Нет свободных ячеек!");
            }*/
            //Рисуем загловки столбцов
            Console.WriteLine("  {0,2}{1,2}{2,2}{3,2}{4,2}{5,2}{6,2}{7,2}{8,2}{9,2}", "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К");
            //Рисуем доску с размещенными в 4-х методах PutShip() кораблями
            for (int i = 0; i < gamingTabel.GetLength(0); i++)
            {
                //Рисуем загловки строк
                Console.Write("{0,2}", i + 1);
                for (int j = 0; j < gamingTabel.GetLength(1); j++)
                {
                    /*Отрисовываем иксом все ячеки с кораблями 1-однопалубные 2-двухпалубные 3-трехпалубные и 4-однопалубный
                     Почему не пометить все корабли одним и тем же числом? например 1, потому что если вывести gamingTabel[i, j]
                    вместо Х то пудет более удобно их (корабли) посчитать*/
                    if (gamingTabel[i, j] >= 1 & gamingTabel[i, j] <= 4)
                    {
                        Console.Write("{0,2}", "X" /*gamingTabel[i, j]*/);
                    }
                    else
                    {
                        Console.Write("{0,2}", "O"); //Если ячека пуста то выводим О
                    }
                }
                //Переходим на следующую строку
                Console.WriteLine();
            }
        }
        //Самый главный метод, который размещает корабли, принимает 2 параметра - тип корабля, который надо разместить и количество кораблей данного типа
        static void PutShip(Ship _shipToPut, int _timesToPut)
        {
            bool isLocationOccupied = false; //Сразуже объявляем переменную занята ли ячека

            for (int k = 1; k <= _timesToPut; k++) //цикл размещает столько кораблей сколько нужно (в каждой итерации размещается по одному кораблю)
            {
                //Объявляем массив свободных ячеек с начальными координатами корабля
                List<List<int>> availableCells = new List<List<int>>();
                //Объявляем массив ориентаций корабля
                List<Orientation> availableCellsOrientation = new List<Orientation>();
                /*Здесь надо пояснить: оба массива будут заполняться одновременно и один и тотже индекс в обоих массивах будет указывать на одну
                 и туже ячеку, только availableCells - содержит координаты этой ячейки, а availableCellsOrientation - ориентацию корабля в той же ячейке*/
                //Пусть ориентация корабля горизонтальная,
                _shipToPut.Orientation = Orientation.Horizontal;
                //тогда: 
                for (int i = 0; i < gamingTabel.GetLength(0); i++)//Проходимся по всем строкам
                {
                    for (int j = 0; j < gamingTabel.GetLength(1) - (int)_shipToPut.Type + 1; j++)//Но не по всем столбцам, а только до того столбца, чтобы корабль не вылез за пределы поля
                    {
                        isLocationOccupied = false; //пока про ячеку ничего не знаем, и она у нас свободна
                        for (int l = j; l < j + (int)_shipToPut.Type; l++) //Проходимся встроку, т.к. корабль расположен горизонтально, по всем ячекам, которые корабль мог бы занять
                        {
                            if (gamingTabel[i, l] != 0)//И если натыакемся на не свободную ячеку, значит начиная с i, j и при данной ориентации поместить корабль не можем 
                            {
                                isLocationOccupied = true;//Помечаем перменную как true, что готоворит, что текущая начальная ячейка занята(имя ввиду что занята хотяб одна ячека куда встал бы корабль занята)
                                break;//И сразуже выходим из цикла, т.к. дальше идти смысла нет
                            }
                        }
                        //если все ячейки в цикле l пустые, то
                        if (!isLocationOccupied)
                        {
                            //запоминаем эту начальную ячейку и ориентацию корябля в массив
                            availableCells.Add(new List<int> { i, j });
                            availableCellsOrientation.Add(_shipToPut.Orientation);
                        }
                    }
                }
                //Пусть ориентация корабля вертикальная, тогда проделываем все тоже самое, только с учетом ориентации
                _shipToPut.Orientation = Orientation.Vertical;
                for (int i = 0; i < gamingTabel.GetLength(0) - (int)_shipToPut.Type + 1; i++)
                {
                    for (int j = 0; j < gamingTabel.GetLength(1); j++)
                    {
                        for (int l = i; l < i + (int)_shipToPut.Type; l++)
                        {
                            isLocationOccupied = false;
                            if (gamingTabel[l, j] != 0)
                            {
                                isLocationOccupied = true;
                                break;
                            }
                        }
                        if (!isLocationOccupied)
                        {
                            availableCells.Add(new List<int> { i, j });
                            availableCellsOrientation.Add(_shipToPut.Orientation);
                        }
                    }
                }

                Random randomCell = new Random();
                int availableCellToPut = 0;
                //выбираем случайную ячейку куда поместить корабль
                availableCellToPut = randomCell.Next(0, availableCells.Count);
                //Запоминаем начальные координаты корабля в более понятные по названию переменные
                int startRow = availableCells[availableCellToPut][0];
                int startColumn = availableCells[availableCellToPut][1];
                int endRow;
                int endColumn;
                /*if (availableCells.Count != 0)
                {
                isNull = false;*/
                //Если расположение корябля в данной случайно ячейке горизонтальное, то
                if (availableCellsOrientation[availableCellToPut] == Orientation.Horizontal)
                {
                    //startRow = availableCells[availableCellToPut][0];
                    //startColumn = availableCells[availableCellToPut][1];
                    //endRow = availableCells[availableCellToPut][0];
                    //Рисуем корабль по горизонтали, 
                    endColumn = availableCells[availableCellToPut][1] + (int)_shipToPut.Type - 1;
                    for (int n = startColumn; n <= endColumn; n++)
                    {
                        gamingTabel[startRow, n] = (int)_shipToPut.Type; //а точнее помечаем ячейки как занятые числом равным количеству палуб корябля (можно пометить 1, просто если отрисовать в строке 97 именно число, а не Х, то будет проще корабли посчитать)
                        //Помечаем ячейки вокруг каждой палубы как занятые "-1"
                        addEmptySpaces(startRow, n, -1);
                    }
                }
                //Если расположение корябля в данной случайно ячейке вертикальное, то рисуем по вертикали
                if (availableCellsOrientation[availableCellToPut] == Orientation.Vertical)
                {
                    //startRow = availableCells[availableCellToPut][0];
                    //startColumn = availableCells[availableCellToPut][1];
                    endRow = availableCells[availableCellToPut][0] + (int)_shipToPut.Type - 1;
                    //endColumn = availableCells[availableCellToPut][1];
                    for (int m = startRow; m <= endRow; m++)
                    {
                        gamingTabel[m, startColumn] = (int)_shipToPut.Type;
                        addEmptySpaces(m, startColumn, -1);
                    }
                }
            }
            /*else
            {
                isNull = true;
            }*/
        }
        //Помечаем ячеки вокруг палубы как занятые, RowIndex-индекс строки палубы корабля, ColumnIndex-индекс строки палубы корабля, _emptySpaceSign - то чем будем заполнять пространство вокруг корябля
        static void addEmptySpaces(int rowIndex, int ColumnIndex, int _emptySpaceSign)
        {
            //В циклах i и j проходимся по всем 9 ячейкам вокруг палубы, включая саму палубу
            for (int i = rowIndex - 1; i < rowIndex + 2; i++)
            {
                for (int j = ColumnIndex - 1; j < ColumnIndex + 2; j++)
                {
                    //Условие, позволяющее избежать ошибки, если корабль стоит у края
                    if (i >= 0 & i < gamingTabel.GetLength(0) & j >= 0 & j < gamingTabel.GetLength(1))
                    {
                        //Если ячека свободна (не (int)_shipToPut.Type и не _emptySpaceSign), то запоняем ее как занятую, чтобы другой корабль в нее не встал
                        if (gamingTabel[i, j] == 0)
                        {
                            gamingTabel[i, j] = _emptySpaceSign;
                        }
                    }
                }
            }
        }
    }
}
