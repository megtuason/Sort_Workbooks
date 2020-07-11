using System;
using System.Collections.Generic;

namespace help
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CrazyLibrary crayLib = new CrazyLibrary();
            int choice;

            do
            {
                Console.WriteLine("=====CRAY CRAY DRUGSTORE=====" + "\n" + "1 Line up" + "\n" + "2 Serve" + "\n" + "3 Rotate" + "\n" + "4 Display" + "\n" + "0 Exit");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();

                    if (crayLib.FindCustomer(name) != null) //checks if customer is already in list
                    {
                        crayLib.Lineup2(crayLib.FindCustomer(name)); //goes to lineup2 which only asks for name
                    }
                    else
                    {
                        Console.WriteLine("Enter age"); 
                        int age = int.Parse(Console.ReadLine());
                        crayLib.Lineup(name, age);
                        Console.WriteLine();
                    }
                }
                else if (choice == 2)
                {
                    crayLib.Serve();
                    Console.WriteLine();
                }
                else if (choice == 3)
                {
                    crayLib.Rotate();
                    Console.WriteLine();
                }
                else if (choice == 4)
                {
                    crayLib.Display();
                    Console.WriteLine();
                }
            }
            while (choice != 0);
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public class Customer
        {
            public Customer(string name, int age)
            {
                GetName = name;
                GetAge = age;
            }
            public string GetName
            {
                get; set;
            }
            public int GetAge
            {
                get; set;
            }

        }
        private class Node
        {
            public Customer Item { get; set; }
            public Node Next { get; set; }
            public Node(Customer item)
            {
                Item = item;
                Next = null;
            }
            public Node(Customer item, Node previous)
            {
                Item = item;
                Next = null;
                previous.Next = this;
            }
        }
        public class NodeQueue
        {
            Node front;
            Node back;
            int count;
            public NodeQueue()
            {
                front = null;
                back = null;
                count = 0;
            }

            public int Count
            {
                get { return count; }
            }

            public void Enqueue(Customer item)
            {
                if (front == null && back==null)
                {
                    front = new Node(item); 
                    back = front;
                } 
                else
                {
                    Node newNode = new Node(item, back);
                    back = newNode;
                }
                count++;

            }
            public Customer Dequeue()
            {

                Customer cus = null;

                if (count == 1)
                {
                    cus = front.Item;
                    front = null;
                    back = null;
                    count--;
                }
                else
                {
                    cus = front.Item;
                    front = front.Next;
                    count--;
                    return cus;
                }

                return cus;

            }
            public void Reverse() 
            {
                Node curr = front;
                Node next;
                Node prev = null;
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
                back = prev;
                while (curr != null)
                {
                    next = curr.Next;
                    curr.Next = prev;
                    prev = curr;
                    curr = next;
                }
                front = prev;

            }
            public List<Customer> Show()
            {
                List<Customer> TempList = new List<Customer>();
                Node curr = front;
                while (curr != null)
                {
                    TempList.Add(curr.Item);
                    curr = curr.Next;
                }
                return TempList;
            }

			public int LineChecker(Customer item) 
			{
				int checker = 0;
				Node temp = front; 
                for (int i = 0; i < count; i++)
				{
                    if (temp.Item == item)
					{
						checker = 1;
						break;
					}
                    temp = temp.Next;
				}

				return checker;
			}

		}

        public class PriorityQueue
        {
            public Customer[] SeniorQueue;
            public List<string> Its = new List<string>();
            int count=0;
            int reversecount;
             

            public PriorityQueue()
            {
                SeniorQueue = new Customer[100];
            }

            public int Count
            {
                get { return count; }
            }

            public void Enqueue(Customer item)
            {
                if (count == 100)
                {
                    Console.WriteLine("Priority queue is full!");
                }
                else 
                {
                    SeniorQueue[count] = item; //adds new element
                    count++;
                    Heapify(SeniorQueue,count); //makes it into a heap
                }
            }

            public Customer Dequeue()
            {
                Customer temp;
                Heapify(SeniorQueue,count); //makes it into a heap
                temp = SeniorQueue[0];     //max/min heap becomes temp
                SeniorQueue[0] = SeniorQueue[count - 1]; //last element becomes max/min heap
                SeniorQueue[count - 1] = null; //delete last element
                count--; 
                Heapify(SeniorQueue,count); //makes it into a heap

                return temp;
            }

            public void Reverse()
            {

                reversecount++; //add to reversecounter
            }


            public void GetInfo()
            {
                Customer[] temp = SeniorQueue; //make temp array (did this para di na magulo yung heap hehe)

                SelectionSort(temp); //sort the temp array

				if (reversecount % 2 == 0) //if it's even --> oldest first
				{
                    Console.WriteLine("Now Serving: oldest first");
					for (int i = count - 1; i >= 0; i--)
					{
                       
                        Console.WriteLine(count-i + "." + SeniorQueue[i].GetName + "," + SeniorQueue[i].GetAge);
						
					}
				}
                else
                {
                    Console.WriteLine("Now Serving: youngest first");
					for (int i = 0; i < count; i++) //youngest first
					{
						Console.WriteLine(i + 1 + "." + SeniorQueue[i].GetName + "," + SeniorQueue[i].GetAge);
					}

                }
                
             }
               public Customer[] SelectionSort(Customer[] A) //i used selection but you can use any sort hehe 
				{
                for (int i = 0; i < count - 1; i++)
					{
                    int min = i;
                   
                    for (int j = i + 1; j < count; j++)
						{
                        if (A[j].GetAge < A[min].GetAge)
							{
								min = j;
							}
						}

						if (min != i)
						{
                        Customer place = A[i];
                                A[i] = A[min];
                                A[min] = place;
						}
					}
					return A;
				}
			

			public int LineChecker(Customer item) //line checker for priority queue
			{
				int checker = 0;

				for (int i = 0; i < count; i++)
				{
                    if (SeniorQueue[i] == item)
					{
						checker = 1;
						break;
					}
				}

				return checker;
			}

            public void Heapify(Customer[]a,int n) //makes array into a heap
            {
                for (int i = 1; i < n;i++) 
                {
                    if(reversecount%2==0) //if max heap
                    {
                        int parent = GetParent(i); //parent is = to the parent of i(child)
                        Customer temp;

                        if(a[i].GetAge>a[parent].GetAge) //if child is bigger than parent, switch
                        {
                            temp = a[i];
                            a[i] = a[parent]; 
                            a[parent] = temp;

                            if(i>2) //if more than one parent, like there's an ancestor pa above
                            {
                                while(parent!=0) 
                                {
                                    int gp = GetParent(parent); //gp becomes the parent of the parent
                                    if(a[parent].GetAge>a[gp].GetAge) //if parent is bigger than gp,switch
                                    {
                                        temp = a[parent];
                                        a[parent] = a[gp];
                                        a[gp] = temp;
                                    }

                                    parent = gp; //parent = gp so that loop doesn't become infinite
                                }
                            }
                        }

                    }
                    else //min heap (same thing but just changed the signs)
                    {
						int parent = GetParent(i);
						Customer temp;

						if (a[i].GetAge < a[parent].GetAge)
						{
							temp = a[i];
							a[i] = a[parent];
							a[parent] = temp;

							if (i > 2)
							{
								while (parent != 0)
								{
									int gp = GetParent(parent);
									if (a[parent].GetAge < a[gp].GetAge)
									{
										temp = a[parent];
										a[parent] = a[gp];
										a[gp] = temp;
									}

									parent = gp;
								}
							}
						}
                    }
                }
            }

            int GetParent(int c) //formula for getting the parent
            {
                int parent = 0;
                if(c%2!=0)
                {
                    parent = (c - 1) / 2;

                }
                else if(c%2==0)
                {
                    parent = (c - 2) / 2;
                }

                return parent;
            }
        }

        public class CrazyLibrary
        {
            public List<Customer> CustomerList = new List<Customer>();
            NodeQueue CustomerQueue = new NodeQueue();
            PriorityQueue SeniorQueue = new PriorityQueue();
            public Customer FindCustomer(string name)
            {
                foreach (Customer a in CustomerList)
                {
                    if(a.GetName == name)
                    {
                        return a;
                    }
                }
                return null;
            }


            public void Lineup(string name, int age)
            {
                
                if (FindCustomer(name) == null)
                {
                    CustomerList.Add(new Customer(name, age));
                    Console.WriteLine("Welcome " + name + "!");
                }
                if ((FindCustomer(name).GetName == name) && (FindCustomer(name).GetAge == age))
                {
                    Customer cus = FindCustomer(name);
                    if (cus.GetAge >= 65)
                    {
                        SeniorQueue.Enqueue(cus);
                        Console.WriteLine("Priority customer has been queued");
                    }
                    else if (cus.GetAge < 65)
                    {
                        CustomerQueue.Enqueue(cus);
                        Console.WriteLine("Your place in line: " + CustomerQueue.Count);
                    }
                }

            }

            public void Lineup2(Customer item) //uses linechecker
            {
                if (item.GetAge >= 65)
				{
					if (SeniorQueue.Count == 100)
					{
						Console.WriteLine("Priority Queue is Full.");
					}

					else
					{
                        if (SeniorQueue.LineChecker(item) == 1)
						{
							Console.WriteLine("ERROR: Customer is already currently lined up\n");
						}

						else
						{
                            SeniorQueue.Enqueue(item);
							Console.WriteLine("A prior senior customer has lined up\n");
						}
					}
				}

				else
				{
                    if (CustomerQueue.LineChecker(item) == 1)
					{
						Console.WriteLine("ERROR: Customer is already currently lined up\n");
					}

					else
					{
                        CustomerQueue.Enqueue(item);
						Console.WriteLine("A prior customer has lined up\n");
					}
				}
            }

            public void Serve()
            {
                if ((CustomerQueue.Count == 0) && (SeniorQueue.Count == 0))
                {
                    Console.WriteLine("There are no customers to be served.");
                }
                else
                {
                    if (SeniorQueue.Count > 0)
                    {
                        Console.WriteLine(SeniorQueue.Dequeue().GetName + " has been served.");
                    }
                    else if (CustomerQueue.Count > 0)
                    {
                        Console.WriteLine(CustomerQueue.Dequeue().GetName + " has been served.");
                    }
                }
            }

            public void Rotate()
            {
                if ((CustomerQueue.Count == 0) && (SeniorQueue.Count == 0))
                {
                    Console.WriteLine("There are no customers in line.");
                }
                if (SeniorQueue.Count > 0)
                {
                    SeniorQueue.Reverse();
                    Console.WriteLine("Priority queue has been reorganized.");

                }
                if (CustomerQueue.Count > 0)
                {
                    CustomerQueue.Reverse();
                    Console.WriteLine("Serving counter has been relocated.");
                }
            }

            public void Display()
            {
                if ((SeniorQueue.Count == 0) && (CustomerQueue.Count == 0))
                {
                    Console.WriteLine("There are no customers in line.");
                }
                else
                {
                    if (SeniorQueue.Count > 0)
                    {
                        Console.WriteLine("Senior Queue:");
                        SeniorQueue.GetInfo(); //prints senior queue
				
                    }
                    if (CustomerQueue.Count > 0)
                    {
                        Console.WriteLine("Customer Queue:");
                        int i = 1;
                        foreach (Customer a in CustomerQueue.Show())
                        {
                            Console.WriteLine(i + ". " + a.GetName + ", " + a.GetAge);
                            i++;
                        }
                    }
                }
            }


        }
    }
}
