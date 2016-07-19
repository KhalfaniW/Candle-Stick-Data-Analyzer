# Candle-Stick-Data-Analyzer

This my first large applicaition.

It was created to take the historical forex market candle stick data from: https://www.dukascopy.com/swiss/english/marketwatch/historical/
and run tests on it.

The most prominent test is called the [Bollinger Band](http://www.investopedia.com/terms/b/bollingerbands.asp): the Bollinger  band is a series of lines plotted two standard deviations away from the average of the candlestick close prices.

I emulated the Bollinger Band in Visual Basic and split the results by month to show whether the accuracy of the Bollinger Band changed from month to month. 

This code took me the whole of last summer to write and it has not been tested since. It requires Visual Studio (old versions are free) to compile and deploy, but I have foregone Windows because my hardrive got corrupted.
 
**Indicators.vb** is the file that emulates Bollinger Band as well as a few other statistical analytics tools.

**FrmMain.vb** is the file that does all the calcualtions: splitting the files into, months, sending it to Indicators.vb

**InputCandle.vb**  is a late addition: it was created to add candle stick data manually, it may be unstable. 
This code may be unstable but it worked before

####Example Candlestick Data
```
Time,Open,High,Low,Close,Volume
01.01.2015 00:00:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:01:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:02:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:03:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:04:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:05:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:06:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:07:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:08:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:09:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:10:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:11:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:12:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:13:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:14:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:15:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:16:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:17:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:18:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:19:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:20:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:21:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:22:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:23:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:24:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:25:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:26:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:27:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:28:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:29:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:30:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:31:00.000,97.694,97.694,97.694,97.694,0.0000
01.01.2015 00:32:00.000,97.694,97.694,97.694,97.694,0.0000
```


