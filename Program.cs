using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();

        Console.WriteLine("กรุณากรอกตัวเลข (พิมพ์ q เพื่อหยุดการกรอก):");

        while (true)
        {
            Console.Write("ตัวเลข: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
                break;

            if (double.TryParse(input, out double num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("กรุณากรอกตัวเลขที่ถูกต้อง");
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("ไม่มีข้อมูลสำหรับการคำนวณ");
            return;
        }

        CalculateAndDisplay(numbers);
    }

    static void CalculateAndDisplay(List<double> numbers)
    {
        double average = numbers.Average();
        double max = numbers.Max();
        double min = numbers.Min();
        double median = CalculateMedian(numbers);

        Console.WriteLine("\nผลลัพธ์การคำนวณ");
        Console.WriteLine($"ค่าเฉลี่ย: {average}");
        Console.WriteLine($"ค่าสูงสุด: {max}");
        Console.WriteLine($"ค่าต่ำสุด: {min}");
        Console.WriteLine($"ค่ากลางข้อมูล (Median): {median}");

        Console.WriteLine("\nเรียงจากน้อยไปมาก:");
        foreach (var n in numbers.OrderBy(n => n))
            Console.Write(n + " ");

        Console.WriteLine("\n\nเรียงจากมากไปน้อย:");
        foreach (var n in numbers.OrderByDescending(n => n))
            Console.Write(n + " ");
    }

    static double CalculateMedian(List<double> numbers)
    {
        var sorted = numbers.OrderBy(n => n).ToList();
        int count = sorted.Count;

        if (count % 2 == 0)
        {
            return (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
        }
        else
        {
            return sorted[count / 2];
        }
    }
}
