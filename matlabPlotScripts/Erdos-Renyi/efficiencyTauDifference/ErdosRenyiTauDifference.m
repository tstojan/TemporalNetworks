%  read labels and x-y data
load ErdosRenyiTemporalMetricsPlotsTau_100.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalMetricsPlotsTau_100(:,2);     %  copy first column of my_xy into x
Err1 = ErdosRenyiTemporalMetricsPlotsTau_100(:,3);     %  and second column into y

load ErdosRenyiTemporalMetricsPlotsTau_50.dat;     %  read data into the my_xy matrix
Err2 = ErdosRenyiTemporalMetricsPlotsTau_50(:,3);     %  and second column into y

load ErdosRenyiTemporalMetricsPlotsTau_20.dat;     %  read data into the my_xy matrix
Err3 = ErdosRenyiTemporalMetricsPlotsTau_20(:,3);     %  and second column into y

load ErdosRenyiTemporalMetricsPlotsTau_10.dat;     %  read data into the my_xy matrix
Err4 = ErdosRenyiTemporalMetricsPlotsTau_10(:,3);     %  and second column into y

semilogx(Prob,Err1,'k.-',Prob,Err2,'b.-',Prob,Err3,'r.-',Prob,Err4,'g.-');

xlabel('p');           % add axis labels and plot title
ylabel('Average Temporal Efficiency');
axis([0.0001 1.000 0.0 1.000],[0.0001 1.000 0.0 1.000]);
set(gca,'XScale','log','XGrid','on','YGrid','on','XMinorGrid','off');
%grid on;
legend('\tau = 100.0','\tau = 50.0','\tau = 20.0','\tau = 10.0');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles