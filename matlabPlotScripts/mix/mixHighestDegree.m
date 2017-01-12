%  read labels and x-y data
load CabSpottingHighestDegreeTemporalRobustness.txt;     %  read data into the my_xy matrix
Prob = CabSpottingHighestDegreeTemporalRobustness(:,2);     %  copy first column of my_xy into x
Err1 = CabSpottingHighestDegreeTemporalRobustness(:,3);     %  and second column into y

load infocom2006_day2345_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err2 = infocom2006_day2345_trace_AverageHighestDegree(:,3);     %  and second column into y

load RWP_10_4_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err3 = RWP_10_4_trace_AverageHighestDegree(:,3);     %  and second column into y

load RWP_10_2_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err4 = RWP_10_2_trace_AverageHighestDegree(:,3);     %  and second column into y

load RPGM_20x5_10_4_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err5 = RPGM_20x5_10_4_trace_AverageHighestDegree(:,3);     %  and second column into y

load RPGM_20x5_10_2_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err6 = RPGM_20x5_10_2_trace_AverageHighestDegree(:,3);     %  and second column into y

load MarkovTemporalAverageHighestDegreePlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Err7 = MarkovTemporalAverageHighestDegreePlots_100_q_0_0010(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0010.dat;     %  read data into the my_xy matrix
Err8 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0010(:,3);     %  and second column into y


plot(Prob,Err1,'k.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'c.-',Prob,Err5,'r.-',Prob,Err6,'m.-',Prob,Err7,'y.-');

xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('Cab-Spotting','INFOCOM','RWP (P_{ON} = 10^{-4})','RWP (P_{ON} = 10^{-2})','RWPG (P_{ON} = 10^{-4})','RWPG (P_{ON} = 10^{-2})','Markov & Erdos-Renyi');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles