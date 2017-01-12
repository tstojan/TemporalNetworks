%  read labels and x-y data
load RWP_10_4_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Prob = RWP_10_4_trace_RandomErrors(:,2);     %  copy first column of my_xy into x
Err1 = RWP_10_4_trace_RandomErrors(:,3);     %  and second column into y

load RWP_10_3_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Err2 = RWP_10_3_trace_RandomErrors(:,3);     %  and second column into y

load RWP_10_2_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Err3 = RWP_10_2_trace_RandomErrors(:,3);     %  and second column into y

load RWP_10_1_trace_RandomErrors.dat;     %  read data into the my_xy matrix
Err4 = RWP_10_1_trace_RandomErrors(:,3);     %  and second column into y

plot(Prob,Err1,'k.-',Prob,Err2,'b.-',Prob,Err3,'r.-',Prob,Err4,'g.-');

xlabel('P_{error}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('P_{ON} = 10^{-4}','P_{ON} = 10^{-3}','P_{ON} = 10^{-2}','P_{ON} = 10^{-1}');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles