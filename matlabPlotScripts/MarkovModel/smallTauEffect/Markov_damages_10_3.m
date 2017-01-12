%  read labels and x-y data
load MarkovTemporalRandomErrorsPlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Prob = MarkovTemporalRandomErrorsPlots_100_q_0_0010(:,2);     %  copy first column of my_xy into x
Err1 = MarkovTemporalRandomErrorsPlots_100_q_0_0010(:,3);     %  and second column into y

load MarkovTemporalClosenessPlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Err2 = MarkovTemporalClosenessPlots_100_q_0_0010(:,3);     %  and second column into y

load MarkovTemporalFinalHighestDegreePlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Err3 = MarkovTemporalFinalHighestDegreePlots_100_q_0_0010(:,3);     %  and second column into y

load MarkovTemporalAverageHighestDegreePlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Err4 = MarkovTemporalAverageHighestDegreePlots_100_q_0_0010(:,3);     %  and second column into y

load MarkovTemporalContactUpdatesPlots_100_q_0_0010.dat;     %  read data into the my_xy matrix
Err5 = MarkovTemporalContactUpdatesPlots_100_q_0_0010(:,3);     %  and second column into y


plot(Prob,Err1,'r.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'m.-',Prob,Err5,'k.-');
xlabel('P_{error/attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.210],[0.000075 1.000 0.0 1.210]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('Random Errors','Closeness','Final highest degree','Average highest degree','No. contacts/updates');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles