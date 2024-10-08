﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cocult.Comands
{
    /// <summary>
    /// класс для вывода информаци об командах
    /// </summary>
    class ComandHelp : IComand
    {
        private List<IComand> _comands;

        public string NameComand { get; set; }

        public ComandHelp(List<IComand> comands)
        {
            this.NameComand = "help";
            _comands = comands;
        }

        public void Execute(string data)
        {
            List<IExample> examples = _comands
                .Where(t => t is IExample)
                .Cast<IExample>()
                .ToList();

            foreach (var el in examples)
            {
                Console.WriteLine(el.Example() + "\n");
            }
        }
    }
}
