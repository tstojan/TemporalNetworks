%  read labels and x-y data
load ErdosRenyiTimeDepandances_100.dat;     %  read data into the my_xy matrix
Time = ErdosRenyiTimeDepandances_100(:,1);     %  copy first column of my_xy into x
Eff = ErdosRenyiTimeDepandances_100(:,2);     %  and second column into y


plot(Time,Eff,'r.-');
xlabel('time');           % add axis labels and plot title
ylabel('Average Temporal Efficiency');

%set(gca,'gridlinestyle','- -')
grid on;
%legend('Simulation N = 100','Theoretical N = 100','Simulation N = 1000','Theoretical N = 1000');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles