%  read labels and x-y data
load MarkovTemporalMetricsPlots_100_0_0001.dat;     %  read data into the my_xy matrix
Prob = MarkovTemporalMetricsPlots_100_0_0001(:,2);     %  copy first column of my_xy into x
Eff1 = MarkovTemporalMetricsPlots_100_0_0001(:,5);     %  and second column into y

load MarkovTemporalMetricsPlots_100_0_0010.dat;     %  read data into the my_xy matrix
Eff2 = MarkovTemporalMetricsPlots_100_0_0010(:,5);     %  and second column into y

load MarkovTemporalMetricsPlots_100_0_0100.dat;     %  read data into the my_xy matrix
Eff3 = MarkovTemporalMetricsPlots_100_0_0100(:,5);     %  and second column into y

load MarkovTemporalMetricsPlots_100_0_1000.dat;     %  read data into the my_xy matrix
Eff4 = MarkovTemporalMetricsPlots_100_0_1000(:,5);     %  and second column into y

load MarkovTemporalMetricsPlots_100_1_0000.dat;     %  read data into the my_xy matrix
Eff5 = MarkovTemporalMetricsPlots_100_1_0000(:,5);     %  and second column into y

semilogx(Prob,Eff1,'r.-',Prob,Eff2,'b.-',Prob,Eff3,'g.-',Prob,Eff4,'c.-',Prob,Eff5,'y.-');
xlabel('p');           % add axis labels and plot title
ylabel('Temporal Length');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
set(gca,'XScale','log','XGrid','off','YGrid','on');
%set(gca,'gridlinestyle','--')
%grid on;
legend('q = 10^{-4}','q = 10^{-3}','q = 10^{-2}','q = 10^{-1}','q = 1');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles