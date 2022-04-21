using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter Date dd/mm/yyyy Format");
			
			try
			{
				string dateval = Console.ReadLine();
				string[] arr = dateval.Split('/');
				int day = Convert.ToInt32(arr[0]);
				int d = Convert.ToInt32(day);
				d = d + 1;
				arr[0] = Convert.ToString(d);
				Console.WriteLine(arr[0] + "/" + arr[1] + "/" + arr[2]);
				int m = Convert.ToInt32(Console.ReadLine());
				int y = Convert.ToInt32(Console.ReadLine());

				if (d > 0 && d < 28)    //checking for day from 0 to 27
					d += 1;
				if (d == 28)
				{
					if (m == 2) //checking for february
					{
						if ((y % 400 == 0) || (y % 100 != 0 || y % 4 == 0)) //leap year check in case of feb
						{
							d = 29;
						}
						else
						{
							d = 1;
							m = 3;
						}
					}
					else    //when its not feb
						d += 1;
				}

				Console.WriteLine("New date:{0}/{1}/{2}", d, m, y);
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Please enter values in dd/mm/yyyy format");

			}
		}
    }
}
