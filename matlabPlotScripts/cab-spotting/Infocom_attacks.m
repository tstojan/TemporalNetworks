%  read labels and x-y data
load ContactUpdatesRobustness.txt;     %  read data into the my_xy matrix
Prob = ContactUpdatesRobustness(:,2);     %  copy first column of my_xy into x
Err2 = ContactUpdatesRobustness(:,3);     %  and second column into y

load HighestDegreeTemporalRobustness.txt;     %  read data into the my_xy matrix
Err3 = HighestDegreeTemporalRobustness(:,3);     %  and second column into y

load ClosenessTemporalRibustness.txt;     %  read data into the my_xy matrix
Err1 = ClosenessTemporalRibustness(:,3);     %  and second column into y

load infocom2006_day2345_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Err4 = infocom2006_day2345_trace_RandomErrors(:,3);     %  and second column into y

plot(Prob,Err1,'k.-',Prob,Err2,'b.-',Prob,Err3,'r.-',Prob,Err4,'g.-');

xlabel('P_{error/attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('Temporal Closeness','No. contacts/updates','Highest Degree','Random Errors');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles