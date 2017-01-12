%  read labels and x-y data
load ErdosRenyiTemporalMetricsPlots_100.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalMetricsPlots_100(:,2);     %  copy first column of my_xy into x
LenSim = ErdosRenyiTemporalMetricsPlots_100(:,5);     %  and second column into y
LenTheor = ErdosRenyiTemporalMetricsPlots_100(:,6);     %  and second column into y

load ErdosRenyiTemporalMetricsPlots_1000.dat;     %  read data into the my_xy matrix
LenSim1 = ErdosRenyiTemporalMetricsPlots_1000(:,5);     %  and second column into y
LenTheor1 = ErdosRenyiTemporalMetricsPlots_1000(:,5);     %  and second column into y

semilogx(Prob,LenSim,'r.-',Prob,LenTheor,'rS-',Prob,LenSim1,'b.-',Prob,LenTheor1,'bS-');
xlabel('p');           % add axis labels and plot title
ylabel('Temporal Length');
axis([0.0001 1.000 0.0 80.000],[0.0001 1.000 0.0 80.000]);
set(gca,'XScale','log','XGrid','off','YGrid','on');
%set(gca,'gridlinestyle','--')
%grid on;
legend('Simulation N = 100','Theoretical N = 100','Simulation N = 1000','Theoretical N = 1000');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles