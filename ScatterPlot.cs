using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System;

namespace blekenbleu.OxyScope
{
	public partial class Control
	{
		PlotModel ScatterPlot(string title, uint Xprop)
		{
			PlotModel model = new PlotModel { Title = M.Title };

			model.Axes.Add(new LinearAxis
			{
				Position = AxisPosition.Left,
				Title = M.Yprop,
				Minimum = Ymin,
				Maximum = ymax
			});

			model.Axes.Add(new LinearAxis
			{
				Position = AxisPosition.Bottom,
				Title = M.Xprop0,
						Minimum = Xmin - 0.005 * (Xmax - Xmin),	// space for dot@Xmin
						Maximum = Xmax + 0.005 * (Xmax - Xmin)
			});

			model.Series.Add(Scatter(title, Xprop));
			model.LegendPosition = LegendPosition.TopLeft;
			model.LegendFontSize = 12;
			model.LegendBorder = OxyColors.Black;
			model.LegendBorderThickness = 1;
			return model;
		}

		private ScatterSeries Scatter(string title, uint Xprop)	// 3 possible
		{
			int size = 2;	// plot dot size
			ushort end = (ushort)(M.start[M.which] + M.length);
            OxyColor[] color = { OxyColors.Red, OxyColors.Green, OxyColors.Cyan };

			var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
			for (ushort i = M.start[M.which]; i < end; i++)
				scatterSeries.Points.Add(new ScatterPoint(O.x[Xprop,i], O.x[3,i], size));
			scatterSeries.MarkerFill = color[Xprop];
			scatterSeries.Title = title;
			return scatterSeries;
		}

		void RandomPlot()
		{
			// fill the plot with random data
			Random rnd = new Random();
			double xi;
			Xmin = M.min[0,M.which];	 // RandomPlot()
			Xmax = 100 + Xmin;
			Ymin = M.min[3,M.which];
			ymax = 100 + Ymin;
			xi = 100.0 / M.length;
			for (int i = 0; i < M.length; i++)	// fill the plot
			{
				O.x[3,i] = Ymin + 100 * rnd.NextDouble();
				O.x[0,i] = Xmin;
				Xmin += xi;
			}

			Xmin = M.min[0,M.which];
			plot.Model = ScatterPlot("Random plot", 0);
		}
	}
}
