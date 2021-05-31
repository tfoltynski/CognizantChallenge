using System;
using System.Collections.Generic;
using CognizantChallenge.Domain.Entities;

namespace CognizantChallenge.Infrastructure.Context {
    internal sealed class TaskContextSeed {
        public static IEnumerable<TaskEntity> GetTasks() {
            return new List<TaskEntity> {
                new TaskEntity {
                    Id = Guid.NewGuid(),
                    Description = "Write a program that prints at least 10 members of the Fibonacci sequence, the starting input will be in following format: 2,3",
                    TaskName = "Fibonacci series",
                    Output = "5 8 13 21 34 55 89 144 233 377",
                    Input = "2,3"
                },
                new TaskEntity {
                    Id = Guid.NewGuid(),
                    Description =
                        "You have a collection of integers, 1 to 30. I want you to cycle through this collection. For each number found that is evenly divisible by 3, output the word 'Fizz'. For each number that is evenly divisible by 5, output the word 'Buzz'. For each number that is evenly divisible by both 3 AND 5, output the word 'FizzBuzz'.",
                    TaskName = "FizzBuzz",
                    Output = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz",
                    Input = string.Empty
                },
                new TaskEntity {
                    Id = Guid.NewGuid(),
                    Description =
                        "Write a program that prints at least 25 first prime numbers. Prime number is a number that is greater than 1 and divided by 1 or itself. In other words, prime numbers can't be divided by other numbers than itself or 1.",
                    TaskName = "Prime numbers",
                    Output = "2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97",
                    Input = string.Empty
                },
                new TaskEntity {
                    Id = Guid.NewGuid(),
                    Description =
                        "Write a C# Sharp program that takes four numbers as input to calculate and print the average. The input numbers will be in following format: 10,15,20,30",
                    TaskName = "Average numbers",
                    Output = "18.75",
                    Input = "10,15,20,30"
                }
            };
        }
    }
}