%  read labels and x-y data
load infocom2006_day2345_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Prob = transpose(infocom2006_day2345_trace_TemporalCloseness(:,2));     %  copy first column of my_xy into x
Err1 = transpose(infocom2006_day2345_trace_TemporalCloseness(:,3));     %  and second column into y

load ClosenessTemporalRibustness_Less.txt;     %  read data into the my_xy matrix
Err2 = transpose(ClosenessTemporalRibustness_Less(:,3));     %  and second column into y

filled=[Err2,fliplr(Err1)];

hold on

fillhandle=fill(xpoints,filled,'b');
set(fillhandle,'EdgeColor','b','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('robustness range');