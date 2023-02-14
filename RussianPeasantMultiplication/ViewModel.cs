using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class CalcRow
{
    public int Left { get; set; }
    public int Right { get; set; }
}

public class ViewModel : INotifyPropertyChanged
{
    // n und m m nennt man Faktoren, wobei n n auch als Multiplikator und m m auch als Multiplikand bezeichnet wird.Die Rechnung, gesprochen „ n n mal m m“, heißt Multiplikation, das Ergebnis k k heißt Produkt
    // n*m  multiplier multiplicand product
    private int _multiplier = 1;
    private int _multiplicand = 1;
    private int _product;
    public ObservableCollection<CalcRow> _calcData = new();

    // Declare the event
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<CalcRow> CalcData
    {
        get { return _calcData; }
        set
        {
            _calcData = value;
        }
    }

    public int Multiplier
    {
        get { return _multiplier; }
        set
        {
            _multiplier = value;
            this.OnPropertyChanged("Multiplier");
        }
    }

    public int Multiplicand
    {
        get { return _multiplicand; }
        set
        {
            _multiplicand = value;
            this.OnPropertyChanged("Multiplicand");
        }
    }

    public int Product
    {
        get { return _product; }
        set
        {
            _product = value;
            this.OnPropertyChanged("Product");
        }
    }

    public int Product2
    {
        get { return _multiplier * _multiplicand; }
    }

    public void Calculate()
    {
        int left = _multiplier;
        int right = _multiplicand;
        int product = 0;
        CalcData.Clear();
        while (left > 0)
        {
            CalcRow calcRow = new()
            {
                Left = left,
                Right = right,
            };
            CalcData.Add(calcRow);
            left = left >> 1;
            right = right << 1;

            if (!calcRow.Left.IsEven())
                {
                product += calcRow.Right;
            }
        }
        this.Product = product;
    }


    // Create the OnPropertyChanged method to raise the event
    // The calling member's name will be used as the parameter.
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
