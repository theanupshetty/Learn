using System.Collections.Generic;
using Cluestart.Backend.Data;
using Cluestart.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cluestart.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandbyId(int id)
        {
            var commandItems = _repository.GetCommandById(id);
            return Ok(commandItems);
        }
        [HttpGet]
        [Route("getdata")]
        public ActionResult<int[]> GetData()
        {
            var commandItems = CountOfLetters();
            return Ok(commandItems);
        }
        private int[] Sort()
        {
            int[] intArray = new int[] { 2, 5, 4, 3, 9, 1 };
            int temp = 0;
            for (int i = 0; i <= intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (intArray[i] > intArray[j])
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }
            return intArray;
        }

        private int[] Reverse()
        {
            int[] intArray = new int[] { 2, 5, 4, 3, 9, 1 };
            int i = 0;
            int j = intArray.Length - 1;
            while (i < j)
            {
                var temp = intArray[i];
                intArray[i] = intArray[j];
                intArray[j] = temp;
                i++;
                j--;

            }
            return intArray;
        }

        private string ReverseString(string input = "anup")
        {
            char[] charArray = new char[input.Length];
            for (int i = 0, j = charArray.Length - 1; i <= j; i++, j--)
            {
                charArray[i] = input[j];
                charArray[j] = input[i];
            }
            return new string(charArray);
        }

        private bool CheckForDuiplicateString(string input = "I feel happy when you are")
        {
            string[] inputArray = input.Split(" ");
            for (int i = 0; i <= inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CountOfLetters(string input = "anupshetty")
        {
            char[] charArray = input.ToLower().ToCharArray();
            for (int i = 0; i <= charArray.Length; i++)
            {

            }
            return false;
        }
    }
}