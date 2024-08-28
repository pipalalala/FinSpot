import './SubmitButton.scss';

type SubmitButtonProps = {
  title: string;
  callback: () => void;
};

export const SubmitButton: React.FC<SubmitButtonProps> = ({
  title,
  callback,
}) => {
  return (
    <button type="button" className="submit-button" onClick={() => callback()}>
      {title}
    </button>
  );
};
