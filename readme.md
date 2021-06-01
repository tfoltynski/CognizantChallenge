To run this project:
1. Adjust connection string in appsettings.json
2. Run command in solution: 
dotnet ef database update
3. Run the application

################## Fibonacci #########################

using System;  
  public class FibonacciExample  
   {  
     public static void Main(string[] args)  
      {  
         int n1=0,n2=1,n3,i;
         int[] number = Console.ReadLine().Split(',').Select(Int32.Parse).ToList();
         n1 = number[0];
         n2 = number[1];  
         for(i=2;i<12;++i) //loop starts from 2 because 0 and 1 are already printed    
         {    
          n3=n1+n2;    
          Console.Write(n3+" ");    
          n1=n2;    
          n2=n3;    
         }    
      }  
   }  


################## Average numbers #########################

using System;
using System.Linq;
class Demo {
   static void Main() {
      var arr = Console.ReadLine().Split(',').Select(Int32.Parse).ToList();
      double avg = Queryable.Average(arr.AsQueryable());
      Console.WriteLine(avg);
   }
}


################## FizzBuzz #########################

using System;
class Demo {
   static void Main() {
        for (int i = 1; i <= 30; i++)  
        {  
                if (i % 3 == 0 && i % 5 == 0)  
                {  
                    Console.Write("FizzBuzz ");  
                }  
                else if (i % 3 == 0)  
                {  
                Console.Write("Fizz ");  
                }  
                else if (i % 5 == 0)  
                {  
                Console.Write("Buzz ");  
                }  
                else  
                {  
                    Console.Write(i + " ");  
                }  
        }
   }
}


################## Prime numbers #########################

using System;
class Demo {
    static void Main(string[] args)
    {
        for (int x = 2; x < 10000; x++)
        {
            int isPrime = 0;
            for (int y = 1; y < x; y++)
            {
                if (x % y == 0)
                    isPrime++;

                if(isPrime == 2) break;
            }
            if(isPrime != 2)
            Console.Write(x + " ");

            isPrime = 0;
        }
    }
}
