%  read labels and x-y data
load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0001.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0001(:,2);     %  copy first column of my_xy into x
Err1 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0001(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0010.dat;     %  read data into the my_xy matrix
Err2 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0010(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0100.dat;     %  read data into the my_xy matrix
Err3 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_1000.dat;     %  read data into the my_xy matrix
Err4 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_1000(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1001_0000.dat;     %  read data into the my_xy matrix
Err5 = ErdosRenyiTemporalAttack_AverageHighestDegree_1001_0000(:,3);     %  and second column into y


plot(Prob,Err1,'r.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'m.-',Prob,Err5,'k.-');
xlabel('P_{error/attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('p = 10^{-4}','p = 10^{-3}','p = 10^{-2}','p = 10^{-1}','p = 1');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles