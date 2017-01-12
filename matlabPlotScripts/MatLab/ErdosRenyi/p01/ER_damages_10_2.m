%  read labels and x-y data
load ErdosRenyiTemporalErrors_1000_0100.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalErrors_1000_0100(:,2);     %  copy first column of my_xy into x
Err1 = ErdosRenyiTemporalErrors_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_Closenness_1000_0100.dat;     %  read data into the my_xy matrix
Err2 = ErdosRenyiTemporalAttack_Closenness_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_FinalHighestDegree_1000_0100.dat;     %  read data into the my_xy matrix
Err3 = ErdosRenyiTemporalAttack_FinalHighestDegree_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0100.dat;     %  read data into the my_xy matrix
Err4 = ErdosRenyiTemporalAttack_AverageHighestDegree_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_ContactUpdates_1000_0100.dat;     %  read data into the my_xy matrix
Err5 = ErdosRenyiTemporalAttack_ContactUpdates_1000_0100(:,3);     %  and second column into y


plot(Prob,Err1,'r.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'m.-',Prob,Err5,'k.-');
xlabel('P_{error/attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');
%axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('Random Errors','Closeness','Final highest degree','Average highest degree','No. contacts/updates');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles