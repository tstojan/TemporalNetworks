%  read labels and x-y data
load infocom2006_day2345_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Prob = transpose(infocom2006_day2345_trace_TemporalCloseness(:,2));     %  copy first column of my_xy into x
xpoints=[0.0 0.05 0.1 0.15 0.2 0.25 0.3 0.35 0.4 0.45 0.5 0.55 0.6 0.65 0.7 0.75 0.8 0.85 0.9 0.95];

load infocom2006_day2345_trace_AverageHighestDegree.dat;     %  read data into the my_xy matrix
Err3 = transpose(infocom2006_day2345_trace_AverageHighestDegree(:,3));     %  and second column into y

load HighestDegreeTemporalRobustness_Less.txt;     %  read data into the my_xy matrix
Err4 = transpose(HighestDegreeTemporalRobustness_Less(:,3));     %  and second column into y

filled=[Err4,fliplr(Err3)];

hold on

fillhandle=fill(xpoints,filled,'g');
set(fillhandle,'EdgeColor','g','FaceAlpha',0.5,'EdgeAlpha',0.5);


xlabel('P_{attack}');           % add axis labels and plot title
ylabel('Temporal Robustness');

grid on;
legend('robustness range');