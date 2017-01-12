%  read labels and x-y data
load ErdosRenyiTemporalMetricsPlots_100.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalMetricsPlots_100(:,2);     %  copy first column of my_xy into x
EffSim = ErdosRenyiTemporalMetricsPlots_100(:,3);     %  and second column into y

load MarkovTemporalMetricsPlots_PON.dat;     %  read data into the my_xy matrix
EffSim1 = MarkovTemporalMetricsPlots_PON(:,3);     %  and second column into y

load MarkovTemporalMetricsPlots_RWP.dat;     %  read data into the my_xy matrix
EffSim2 = MarkovTemporalMetricsPlots_RWP(:,3);     %  and second column into y

load MarkovTemporalMetricsPlots_RWPG.dat;     %  read data into the my_xy matrix
EffSim3 = MarkovTemporalMetricsPlots_RWPG(:,3);     %  and second column into y

semilogx(Prob,EffSim,'r.-',Prob,EffSim1,'b.-',Prob,EffSim2,'k.-',Prob,EffSim3,'g.-');
xlabel('P_{ON}');           % add axis labels and plot title
ylabel('Average Temporal Efficiency');
axis([0.0001 1.000 0.0 1.000],[0.0001 1.000 0.0 1.000],[0.0001 1.000 0.0 1.000],[0.0001 1.000 0.0 1.000]);
set(gca,'XScale','log','XGrid','on','YGrid','on','XMinorGrid','off');
%set(gca,'gridlinestyle','--')
%grid on;
legend('Erdos-Renyi','Markov','RWP','RWPG 5');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles