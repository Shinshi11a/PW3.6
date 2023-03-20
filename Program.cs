using System;
using System.Collections.Generic;
using System.Linq;

public class RandomNumbersGenerator
{
    private readonly int _length;
    private readonly Random _random = new Random();
    private readonly List<int> _numbers = new List<int>();
    private double? _variance;
    private double? _standardDeviation;
    private int? _median;

    public RandomNumbersGenerator(int length)
    {
        _length = length;

        for (int i = 0; i < length; i++)
        {
            _numbers.Add(_random.Next());
        }
    }

    public double Variance
    {
        get
        {
            if (!_variance.HasValue)
            {
                double average = _numbers.Average();
                double sum = _numbers.Sum(number => Math.Pow(number - average, 2));
                _variance = sum / (_length - 1);
            }

            return _variance.Value;
        }
    }

    public double StandardDeviation
    {
        get
        {
            if (!_standardDeviation.HasValue)
            {
                _standardDeviation = Math.Sqrt(Variance);
            }

            return _standardDeviation.Value;
        }
    }

    public int Median
    {
        get
        {
            if (!_median.HasValue)
            {
                _numbers.Sort();
                int middle = _length / 2;
                _median = (_length % 2 != 0) ? _numbers[middle] : (_numbers[middle - 1] + _numbers[middle]) / 2;
            }

            return _median.Value;
        }
    }
}