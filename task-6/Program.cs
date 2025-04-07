using System;
using System.Threading;

namespace task_6
{
    public delegate void ThresholdReachedHandler(int thresholdValue);
    public class CounterTriggers
    {
        public int Threshold { get; set; }
        public event ThresholdReachedHandler? ThresholdReached;
        int count = 0;

        public CounterTriggers(int thresholdValue)
        {
            Threshold = thresholdValue;
        }

        public void Increment()
        {
            count++;
            Console.WriteLine($"Counter: {count}");
            if (count == Threshold)
            {
                ThresholdReached?.Invoke(Threshold);
            }
        }
    }

    public class MailNotification
    {
        public void ShowAlert(int thresholdValue)
        {
            Console.WriteLine($"Alert: Threshold of {thresholdValue} reached! Sending email notification.");
        }
    }

    public class SMSNotification
    {
        public void ShowAlert(int thresholdValue)
        {
            Console.WriteLine($"Alert: Threshold of {thresholdValue} reached! Sending SMS notification.{DateTime.Now}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CounterTriggers counter = new(7);
            MailNotification mailNotification = new();
            SMSNotification smsNotification = new();
            counter.ThresholdReached += mailNotification.ShowAlert;
            counter.ThresholdReached += smsNotification.ShowAlert;

            for (int i = 0; i < 10; i++)
            {
                counter.Increment();
                Thread.Sleep(1000);
            }
        }
    }
}
