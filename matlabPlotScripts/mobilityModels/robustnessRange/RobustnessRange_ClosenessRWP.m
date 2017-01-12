%  read labels and x-y data
load RWP_10_4_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Prob = transpose(RWP_10_4_trace_TemporalCloseness(:,2));     %  copy first column of my_xy into x
Err1 = transpose(RWP_10_4_trace_TemporalCloseness(:,3));     %  and second column into y

load TemporalCloseness_RWP_10_4_Less.trace;     %  read data into the my_xy matrix
Err2 = transpose(TemporalCloseness_RWP_10_4_Less(:,3));     %  and second column into y

load RWP_10_3_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Err3 = transpose(RWP_10_3_trace_TemporalCloseness(:,3));     %  and second column into y

load TemporalCloseness_RWP_10_3_Less.trace;     %  read data into the my_xy matrix
Err4 = transpose(TemporalCloseness_RWP_10_3_Less(:,3));     %  and second column into y

load RWP_10_2_trace_TemporalCloseness.dat;     %  read data into the my_xy matrix
Err5 = transpose(RWP_10_2_trace_TemporalCloseness(:,3));     %  and second column into y

load TemporalCloseness_RWP_10_2_Less.trace;     %  read data into the my_xy matrix
Err6 = transpose(TemporalCloseness_RWP_10_2_Less(:,3));     %  and second column into y

set(gca,'FontSize',14);

filled=[Err2,fliplr(Err1)];
xpoints=[Prob,fliplr(Prob)];

hold on

fillhandle=fill(xpoints,filled,'b');
set(fillhandle,'EdgeColor','b','FaceAlpha',0.3,'EdgeAlpha',0.5);

hold on

filled=[Err4,fliplr(Err3)];

hold on

fillhandle=fill(xpoints,filled,'r');
set(fillhandle,'EdgeColor','r','FaceAlpha',0.5,'EdgeAlpha',0.5);

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