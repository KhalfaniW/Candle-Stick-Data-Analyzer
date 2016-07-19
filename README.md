# Candle-Stick-Data-Analyzer

This my first large applicaition.

It was created to take the historical forex market candle stick data from: https://www.dukascopy.com/swiss/english/marketwatch/historical/
and run tests on it.

The most prominent test is called the [Bollinger Band](http://www.investopedia.com/terms/b/bollingerbands.asp): the Bollinger  band is a series of lines plotted two standard deviations away from the average of the candlestick close prices.

I emulated the Bollinger Band in Visual Basic and split the results by month to show whether the accuracy of the Bollinger Band changed from month to month. 

This code took me the whole of last summer to write and it has not been tested since. It requires Visual Studio (old versions are free) to compile and deploy, but I have foregone Windows because my hardrive got corrupted.
 
**Indicators.vb** is the file that emulates Bollinger Band as well as a few other statistical analytics tools.
**FrmMain.vb** is the file that does all the calcualtions: splitting the files into, months, sending it to Indicators.vb
InputCandle.vb is a late addition: it was created to add candle stick data manually, it may be unstable.

This code may be unstable but it worked before


