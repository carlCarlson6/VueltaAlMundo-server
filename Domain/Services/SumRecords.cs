using System.Linq;
using System.Collections.Generic;
using Domain.ValueObjects;
using System;

namespace Domain.Services
{
    public class SumRecords
    {
        public Kilometers Sum(List<Kilometers> kilometersList)
        {
            Double sum = kilometersList.Sum(kilometers => kilometers.Value);
            return new Kilometers(sum);
        }
    }
}
