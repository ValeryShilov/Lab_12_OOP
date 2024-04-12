using Lab_10_lib;
using System.Drawing;

namespace Lab_12_OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            //HashTable<Goods> table = new HashTable<Goods>();
            ////RandomInitOneType(table);
            //Goods g1 = new Goods("One", 100, 20);
            //Goods g2 = new Goods("Two", 120, 23);
            //Goods g3 = new Goods("Three", 120, 13);
            //Goods g4 = new Goods("Four", 120, 45);
            //Goods g5 = new Goods("Five", 130, 10);
            //Goods g6 = new Goods("Six", 230, 51);
            //table.Add(g1);
            //table.Add(g2);
            //table.Add(g3);
            //table.Add(g4);
            //table.Add(g5);
            ////table.Add(g6);
            //table.Print();
            //// table.DeleteEl(g5);
            //Console.WriteLine();
            //table.Print();
            //Console.WriteLine(table.FindPoint(g1));
            //Console.WriteLine(table.FindPoint(g2));
            //Console.WriteLine(table.FindPoint(g3));
            //Console.WriteLine(table.FindPoint(g4));
            //Console.WriteLine(table.FindPoint(g5));
            //Console.WriteLine(table.FindPoint(g6));
            ////Goods goods = new Goods();
            ////goods.RandomInit();
            ////Goods goods1 = new Goods(goods);
            //////goods1.RandomInit();
            ////HElement<Goods> el1 = new HElement<Goods>(goods);
            ////HElement<Goods> el2 = new HElement<Goods>(goods1);
            ////Console.WriteLine(el1);
            ////Console.WriteLine(el2);
            ////Console.WriteLine(el1.Equals(el2));
            HashTable<Goods> hashTableGoods = null;
            HashTable<Product> hashTableProduct = null;
            string type = "";
            string choice;
            do
            {
                Console.WriteLine("\n1.Создание хеш-таблицы");
                Console.WriteLine("2.Добавление элемента в хеш-таблицу(вручную)");
                Console.WriteLine("3.Заполнение хеш-таблицы случайными значениями");
                Console.WriteLine("4.Печать коллекции");
                Console.WriteLine("5.Демонстрация удаления элемента по значению");
                Console.WriteLine("6.Демонстрация копирования");
                Console.WriteLine("7.Демонстрация клонирования");
                Console.WriteLine("8.Удаление хеш-таблицы из памяти");
                Console.WriteLine("9.Перебор коллекции циклом foreach");
                Console.WriteLine("10.Поиск элемента по ключу");
                Console.WriteLine("11.Удаление элемента по ключу");

                Console.WriteLine("0.Выход");
                Console.Write("Выберите пункт: ");
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "0":
                        break;
                    case "1":
                        string choice1;
                        bool isInit = false;
                        do
                        {
                            Console.WriteLine("Выберите тип данных элементов хеш-таблицы\n1.Goods\n2.Product");
                            choice1 = Console.ReadLine();
                            switch (choice1)
                            {
                                case "1":
                                    hashTableGoods = new HashTable<Goods>(Menu.ReadInt("Введите размер хеш-таблицы", "Размер должен быть натуральным чилслом", "+"));
                                    type = "goods";
                                    isInit = true;
                                    Console.WriteLine("Коллекция создана\n");
                                    break;
                                case "2":
                                    hashTableProduct = new HashTable<Product>(Menu.ReadInt("Введите размер хеш-таблицы", "Размер должен быть натуральным чилслом", "+"));
                                    type = "product";
                                    isInit = true;
                                    Console.WriteLine("Коллекция создана\n");
                                    break;
                                default:
                                    Console.WriteLine("Неверно выбран пункт");
                                    break;
                            }
                        } while (!isInit);
                        break;

                    case "2":
                        if (type == "goods")
                        {
                            Goods goods = new Goods();
                            goods.Init();
                            hashTableGoods.Add(goods);
                            Console.WriteLine("Элемент добавлен");
                            break;
                        }
                        if (type == "product")
                        {
                            Product product = new Product();
                            product.Init();
                            hashTableProduct.Add(product);
                            Console.WriteLine("Элемент добавлен");
                            break;
                        }
                        else Console.WriteLine("Коллекция не создана");
                        break;
                    case "3":
                        if (type == "goods")
                        {
                            RandomInitGoods(hashTableGoods, Menu.ReadInt("Введите количество добавляемых элементов", "Кол-во элементов должно быть натуральным числом", "+"));
                            Console.WriteLine("Элементы добавлены.");
                            break;
                        }
                        if (type == "product")
                        {
                            RandomInitProduct(hashTableProduct, Menu.ReadInt("Введите количество добавляемых элементов", "Кол-во элементов должно быть натуральным числом", "+"));
                            Console.WriteLine("Элементы добавлены.");
                            break;
                        }
                        else Console.WriteLine("Коллекция не создана");
                        break;

                    default:
                        Console.WriteLine("Неверно выбран пункт меню");
                        break;
                    case "4":
                        if (type == "goods")
                        {
                            hashTableGoods.Print();
                            Console.WriteLine();
                            break;
                        }
                        if (type == "product")
                        {
                            hashTableProduct.Print();
                            Console.WriteLine();
                            break;
                        }
                        else Console.WriteLine("Коллекция не создана");
                        break;
                    case "5":
                        //if (type == "goods")
                        //{

                        //    hashTableGoods.DeleteEl();
                        //}
                        Goods[] goodsArr = { new Goods("One", 100, 20), new Goods("Two", 120, 23), new Goods("Three", 120, 13), new Goods("Four", 120, 45), new Goods("Five", 130, 10), new Goods("Six", 230, 51) };
                        Goods g1 = new Goods("One", 100, 20);
                        Goods g2 = new Goods("Two", 120, 23);
                        Goods g3 = new Goods("Three", 120, 13);
                        Goods g4 = new Goods("Four", 120, 45);
                        Goods g5 = new Goods("Five", 130, 10);
                        Goods g6 = new Goods("Six", 230, 51);
                        hashTableGoods.Add(g1);
                        hashTableGoods.Add(g2);
                        hashTableGoods.Add(g3);
                        hashTableGoods.Add(g4);
                        hashTableGoods.Add(g5);
                        hashTableGoods.Add(g6);
                        hashTableGoods.Print();
                        //int number = Menu.ReadInt("Выберите какой элемент удалить: ", "Ошибка, данный элемент нельзя выбрать для удаления", "->", 1, 5);
                        hashTableGoods.Remove(g5);
                        Console.WriteLine();
                        hashTableGoods.Print();
                        break;
                    case "6":
                        HashTable<Goods> copyHashTable = hashTableGoods.ShallowCopy();
                        Console.WriteLine("Скопированная коллекция до изменения\n");
                        copyHashTable.Print();

                        hashTableGoods.Add(new Goods("AddedTov", 99, 99));
                        Console.WriteLine("Скопированная коллекция после изменения\n");
                        copyHashTable.Print();
                        break;
                    case "7":
                        var cloneHashTable = (HashTable<Goods>)hashTableGoods.Clone();
                        Console.WriteLine("Склонированная коллекция до изменения\n");
                        cloneHashTable.Print();

                        hashTableGoods.Add(new Goods("AddedTov", 99, 99));
                        Console.WriteLine("Склонированая коллекция после изменения\n");
                        cloneHashTable.Print();
                        
                        break;
                    case "8":
                        if (type == "goods")
                        {
                            hashTableGoods.Clear();
                            Console.WriteLine("Хеш-таблица удалена из памяти");
                            break;
                        }
                        if (type == "product")
                        {
                            hashTableProduct.Clear();
                            Console.WriteLine("Хеш-таблица удалена из памяти");
                            break;
                        }
                        else
                            Console.WriteLine("Хеш-таблица не создана");
                        break;
                    case "9":
                        if (type == "goods")
                        {
                            foreach (var item in hashTableGoods)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                        if (type == "product")
                        {
                            foreach (var item in hashTableProduct)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Хеш-таблица не создана");
                            break;
                        }
                    case "10":
                        if (type == "goods")
                        {                                
                            try
                            {
                                Console.WriteLine(hashTableGoods.FindPointKey(Menu.ReadInt("Введите ключ", "Ключ введен не верно")));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                        if (type == "product")
                        {
                            Console.WriteLine(hashTableProduct.FindPointKey(Menu.ReadInt("Введите ключ", "Ключ введен не верно")));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Хеш-таблица не создана");
                            break;
                        }
                    case "11":
                        if (type == "goods")
                        {
                            hashTableGoods.RemoveKey(Menu.ReadInt("Введите ключ", "Ключ введен не верно"));
                            Console.WriteLine("Элемент з заданным ключом удален");
                            break;
                        }
                        if (type == "goods")
                        {
                            hashTableProduct.RemoveKey(Menu.ReadInt("Введите ключ", "Ключ введен не верно"));
                            Console.WriteLine("Элемент c заданным ключом удален");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Хеш-таблица не создана");
                            break;
                        }
                }
            } while (choice != "0");

        }

        public static void CreateHashTable(HashTable<Goods> table)
        {

        }

        public static void CheckFind()
        {

        }

        public static void RandomInit(HashTable<Goods> table)
        {
            Random rnd = new Random();
            for (int i = 0; i < table.Size; i++)
            {
                Goods rndEl = new Goods();
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        Goods goods = new Goods();
                        goods.RandomInit();
                        rndEl = goods;
                        break;
                    case 2:
                        Product product = new Product();
                        product.RandomInit();
                        rndEl = product;
                        break;
                    case 3:
                        MilkProduct milkProduct = new MilkProduct();
                        milkProduct.RandomInit();
                        rndEl = milkProduct;
                        break;
                    case 4:
                        Toy toy = new Toy();
                        toy.RandomInit();
                        rndEl = toy;
                        break;
                }
                table.Add(rndEl);
            }
        }

        public static void RandomInitGoods(HashTable<Goods> table, int countEl)
        {
            Random rnd = new Random();
            for (int i = 0; i < countEl; i++)
            {
                Goods rndEl = new Goods();
                rndEl.RandomInit();
                table.Add(rndEl);
            }
        }

        public static void ShowAdd()
        {

        }

        public static void RandomInitProduct(HashTable<Product> table, int countEl)
        {
            Random rnd = new Random();
            for (int i = 0; i < countEl; i++)
            {
                Product rndEl = new Product();
                rndEl.RandomInit();
                table.Add(rndEl);
            }
        }
    }
}