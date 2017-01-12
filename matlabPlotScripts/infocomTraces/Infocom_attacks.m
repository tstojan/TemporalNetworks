%  read labels and x-y data
load infocom2006_day2345_trace_AverageContactUpdates.dat;     %  read data into the my_xy matrix
Prob = infocom2006_day2345_trace_AverageContactUpdates(:,2);     %  copy first column of my_xy into x
Err2 = infocom2006_day2345_trace_AverageContactUpdates(:,3);     %  and second column into y

load infocom2006_day2345_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err3 = infocom2006_day2345_trace_AverageHighestDegree(:,3);     %  and second column into y

load infocom2006_day2345_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Err1 = infocom2006_day2345_trace_TemporalCloseness(:,3);     %  and second column into y

load infocom2006_day2345_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Err4 = infocom2006_day2345_trace_RandomErrors(:,3);     %  and second column into y

plot(Prob,Err1,'b.-',Prob,Err2,'r.-',Prob,Err3,'g.-',Prob,Err4,'k.-');

xlabel('P_{error/attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('Temporal Closeness','No. contacts/updates','Highest Degree','Random Errors');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles