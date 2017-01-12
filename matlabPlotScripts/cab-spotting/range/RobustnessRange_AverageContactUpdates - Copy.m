%  read labels and x-y data
load infocom2006_day2345_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Prob = transpose(infocom2006_day2345_trace_TemporalCloseness(:,2));     %  copy first column of my_xy into x
Err1 = transpose(infocom2006_day2345_trace_TemporalCloseness(:,3));     %  and second column into y

load ClosenessTemporalRibustness_Less.txt;     %  read data into the my_xy matrix
Err2 = transpose(ClosenessTemporalRibustness_Less(:,3));     %  and second column into y

load infocom2006_day2345_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err3 = transpose(infocom2006_day2345_trace_AverageHighestDegree(:,3));     %  and second column into y

load HighestDegreeTemporalRobustness_Less.txt;     %  read data into the my_xy matrix
Err4 = transpose(HighestDegreeTemporalRobustness_Less(:,3));     %  and second column into y

load infocom2006_day2345_trace_AverageContactUpdates.dat;     %  read data into the my_xy matrix
Err5 = transpose(infocom2006_day2345_trace_AverageContactUpdates(:,3));     %  and second column into y

load ContactUpdatesRobustness_Less.txt;     %  read data into the my_xy matrix
Err6 = transpose(ContactUpdatesRobustness_Less(:,3));     %  and second column into y

filled=[Err2,fliplr(Err1)];
xpoints=[Prob,fliplr(Prob)];

hold on

fillhandle=fill(xpoints,filled,'b');
set(fillhandle,'EdgeColor','b','FaceAlpha',0.2,'EdgeAlpha',0.2);

hold on

filled=[Err4,fliplr(Err3)];

hold on

fillhandle=fill(xpoints,filled,'r');
set(fillhandle,'EdgeColor','r','FaceAlpha',0.3,'EdgeAlpha',0.3);

hold on

filled=[Err6,fliplr(Err5)];

hold on

fillhandle=fill(xpoints,filled,'g');
set(fillhandle,'EdgeColor','g','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('P_{ON} = 10^{-4}','P_{ON} = 10^{-3}','P_{ON} = 10^{-2}','P_{ON} = 10^{-1}');

%title('Mean monthly precipitation at Portland International Airport');