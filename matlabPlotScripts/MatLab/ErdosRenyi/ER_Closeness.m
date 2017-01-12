%  read labels and x-y data
load ErdosRenyiTemporalAttack_Closenness_1000_0001.dat;     %  read data into the my_xy matrix
Prob = ErdosRenyiTemporalAttack_Closenness_1000_0001(:,2);     %  copy first column of my_xy into x
Err1 = ErdosRenyiTemporalAttack_Closenness_1000_0001(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_Closenness_1000_0010.dat;     %  read data into the my_xy matrix
Err2 = ErdosRenyiTemporalAttack_Closenness_1000_0010(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_Closenness_1000_0100.dat;     %  read data into the my_xy matrix
Err3 = ErdosRenyiTemporalAttack_Closenness_1000_0100(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_Closenness_1000_1000.dat;     %  read data into the my_xy matrix
Err4 = ErdosRenyiTemporalAttack_Closenness_1000_1000(:,3);     %  and second column into y

load ErdosRenyiTemporalAttack_Closenness_1001_0000.dat;     %  read data into the my_xy matrix
Err5 = ErdosRenyiTemporalAttack_Closenness_1001_0000(:,3);     %  and second column into y


plot(Prob,Err1,'r.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'c.-',Prob,Err5,'y.-');
xlabel('P_{err}');           % add axis labels and plot title
ylabel('Temporal Robustness');
axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
grid on;
legend('P_{r} = 10^{-4}','P_{r} = 10^{-3}','P_{r} = 10^{-2}','P_{r} = 10^{-1}','P_{r} = 1');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles