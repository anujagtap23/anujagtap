using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.BitWise
{
    public static class BitwiseProblems
    {
        

        public static void BitwiseMain(string[] args)
        {

            for (var i = 0; i < 5; i++)
            {
                /*
                rules = [
                  ("ALLOW", "192.168.100.0/24"), ("DENY", "192.168.0.5/30"), ("ALLOW", "192.168.1.1/22"), ("DENY", "8.8.8.8/0"), ("ALLOW", "1.2.3.4")
                ]

                access_ok(rules, target_ip)
                # return `True` because it matches the first rule (ALLOW) access_ok(rules, "192.168.100.34") 

                # return `False` because it matches the 4th rule (DENY)  access_ok(rules, "8.8.8.8") 
                */


                string[][] rules = new string[5][];
                rules[0] = new string[2] { "ALLOW", "192.168.100.0/24" };
                rules[1] = new string[2] { "DENY", "192.168.0.5/30" };
                rules[2] = new string[2] { "ALLOW", "192.168.1.1/22" };
                rules[3] = new string[2] { "DENY", "8.8.8.8/0" };
                rules[4] = new string[2] { "ALLOW", "1.2.3.4"};


                Console.WriteLine(Access_OK(rules, "192.168.100.34"));
                Console.WriteLine(Access_OK(rules, "8.8.8.8"));

            }
        }

        static bool Access_OK(string[][] rules, string target)
        {
            string result = "";
        
        foreach(string[] rule in rules)
            {
                int mask = 0; string[] ipValue; long ipAddress, targetIpAddress;
                result = rule[0];
                string ip = rule[1];

                string[] ipBlocks = rule[1].Split('/');

                if (ipBlocks.Length == 1)
                    ipValue = ipBlocks[0].Split('.');
                else
                {
                    mask = Int32.Parse((ipBlocks[1]));
                }

                ipAddress = GetIpValue(ipBlocks[0]);
                targetIpAddress = GetIpValue(target);

                ipAddress = ipAddress & (-1 << (32 - mask));
                targetIpAddress = targetIpAddress & (-1 << (32 - mask));

                if (ipAddress == targetIpAddress)
                    return result.Equals("ALLOW") ? true : false;

            }

            return false;
        }


        static int GetIpValue(string ip)
        {
            string[] i = ip.Split('.');
            return (Int32.Parse(i[0]) << 24) + (Int32.Parse(i[1]) << 16) + (Int32.Parse(i[2]) << 8) + Int32.Parse(i[3]);

        }


    } 
}



//split by .
// 32 bit string by left shifting by 8 bits

