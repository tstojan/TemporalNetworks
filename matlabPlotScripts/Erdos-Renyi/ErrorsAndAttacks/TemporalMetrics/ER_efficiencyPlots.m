%  read labels and x-y data
load ErdosRenyiTemporalMetricsPlots_100.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalMetricsPlots_100(:,2);     %  copy first column of my_xy into x
EffSim = ErdosRenyiTemporalMetricsPlots_100(:,3);     %  and second column into y
EffTheor = ErdosRenyiTemporalMetricsPlots_100(:,4);     %  and second column into y

load ErdosRenyiTemporalMetricsPlots_1000.dat;     %  read data into the my_xy matrix
EffSim1 = ErdosRenyiTemporalMetricsPlots_1000(:,3);     %  and second column into y
EffTheor1 = ErdosRenyiTemporalMetricsPlots_1000(:,3);     %  and second column into y

semilogx(Prob,EffSim,'r.-',Prob,EffTheor,'rS-',Prob,EffSim1,'b.-',Prob,EffTheor1,'bS-');
xlabel('p');           % add axis labels and plot title
ylabel('Average Temporal Efficiency');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
set(gca,'XScale','log','XGrid','on','YGrid','on','XMinorGrid','off');
%set(gca,'gridlinestyle','--')
%grid on;
legend('Simulation N = 100','Theoretical N = 100','Simulation N = 1000','Theoretical N = 1000');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles