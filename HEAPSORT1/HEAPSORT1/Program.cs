using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEAPSORT1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, choice;
            string value;
            lable:
            Console.WriteLine("\t\t\tHEAP SORT\n\nSort the number in which order.\n1)Ascending Order.\n2)Descending Order.");
            Console.Write("\nEnter your choice=");
            choice = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nEnter the size of array=");
            num = Convert.ToInt16(Console.ReadLine());
            HeapSort heap = new HeapSort(num, choice);
            int[] array = new int[num];
            //Taking input from users.
            Console.WriteLine("\nEnter the {0} element of array to sort.\n", num);
            for (int i = 0; i < num; i++)
            {
                Console.Write("Element[{0}]=", i);
                array[i] = Convert.ToInt16(Console.ReadLine());
            }
            heap.heapsortfunction(array);
            heap.printheap(array);
            Console.WriteLine("\nYou want to restart the program so press y or Y for yes and n or N for No.");
            value = Console.ReadLine();
            if (value == "y" || value == "Y")
                goto lable;
            else
                Console.WriteLine("Program has been ended."); 
        }
    }
    class HeapSort
    {
        int NumberOfElements;
        int choice;
        public HeapSort(int n, int choice1)
        {
            choice = choice1;
            NumberOfElements = n;
        }
        public void heapsortfunction(int[] Array1)
        {
            //for building heap structure.
            Bulidheap(Array1);

            int i;
            for(i=NumberOfElements-1;i>=0;i--)
            {
                int Temp;
                Temp = Array1[0];
                Array1[0] = Array1[i];
                Array1[i] = Temp;
                heapify(Array1, i,0);
            }

        }
        public void Bulidheap(int[] Array2)
        {
            int i;
            for(i=NumberOfElements/2-1;i>=0;i--)
            {
                heapify(Array2,NumberOfElements,i);
            }
        }
        public void heapify(int[] Array3,int num,int i)
        {
            int Left=2*i+1;// Left child.
            int Right=2*i+2;// Right child.
            int maximum;
            //here we check the left value is less than numberofelement and Array[Left] value is greater or lesser than Array[i].
            if (choice == 1)
            {
                if ((Left < num) && (Array3[Left] > Array3[i]))
                {
                    maximum = Left;
                }
                else
                {
                    maximum = i;
                }
                // we check right child is greater or not as we check for left.
                if ((Right < num) && (Array3[Right] > Array3[maximum]))
                {
                    maximum = Right;
                }

                //now here we swap the value when the condition is true.(given below)
                if (maximum != i)
                {
                    int Temp;
                    Temp = Array3[i];
                    Array3[i] = Array3[maximum];
                    Array3[maximum] = Temp;

                    //function calling
                    heapify(Array3, num, maximum);
                }
            }
            if(choice==2)
            {
                if ((Left < num) && (Array3[Left] < Array3[i]))
                {
                    maximum = Left;
                }
                else
                {
                    maximum = i;
                }
                // we check right child is greater or not as we check for left.
                if ((Right < num) && (Array3[Right] < Array3[maximum]))
                {
                    maximum = Right;
                }

                //now here we swap the value when the condition is true.(given below)
                if (maximum != i)
                {
                    int Temp;
                    Temp = Array3[i];
                    Array3[i] = Array3[maximum];
                    Array3[maximum] = Temp;

                    //function calling
                    heapify(Array3, num, maximum);
                }
            }
        }
        public void printheap(int[] array)
        {
            Console.WriteLine("\nSorted array.\n");
            for (int i = 0; i < NumberOfElements; i++)
            {
                Console.WriteLine("Element[{0}]={1}", i, array[i]);
            }
        }

    }
}
    