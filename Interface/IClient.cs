using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicheskaya_8.Interface
{
    internal interface IClient
    {
        string Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Otchestvo { get; set; }
        string Phone { get; set; }
        string Pasport { get; set; }
        string DateTimeChange { get; set; }
        string WhatDataChanged { get; set; }
        string WhoChanged { get; set; }
    }
}
