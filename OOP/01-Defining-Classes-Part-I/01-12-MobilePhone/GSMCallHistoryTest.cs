using System;

class GSMCallHistoryTest
{
    public static void RunTest()
    {
        GSM myPhone = new GSM("HTC Desire", "HTC", 550, "Pesho", new Battery(BatteryType.LiIon), new Display(4, 250000));
        myPhone.AddCall(DateTime.Today, DateTime.Today.AddMinutes(5), "0887776987");
        myPhone.AddCall(DateTime.Today, DateTime.Today.AddMinutes(8), "0897556644");
        myPhone.AddCall(DateTime.Today, DateTime.Today.AddMinutes(15), "0887441100");
        myPhone.AddCall(DateTime.Today, DateTime.Today.AddMinutes(23), "0885001122");
        myPhone.AddCall(DateTime.Today, DateTime.Today.AddMinutes(4), "0896559988");

        Console.WriteLine(myPhone);
        Console.WriteLine("-----------Call History-----------");
        foreach (Call call in myPhone.CallHistory)
        {
            Console.WriteLine(call);
        }

        Console.WriteLine("Total price of all calls: ${0:F2}", myPhone.TotalCallsCost(0.37));
        myPhone.DeleteLongestCall();
        Console.WriteLine("After the remove of the longest call the total price is: ${0:F2}", myPhone.TotalCallsCost(0.37));
        Console.WriteLine();

        myPhone.ClearHistory();
        Console.WriteLine("-----------Cleared Call History-----------");
        if (myPhone.CallHistory.Count == 0)
        {
            Console.WriteLine("There are no Recorded Calls in the History!");
        }
        else
        {
            foreach (Call call in myPhone.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}