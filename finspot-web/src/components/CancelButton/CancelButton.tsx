import './CancelButton.scss';

type CancelButtonProps = {
  title: string;
  callback: () => void;
};

export const CancelButton: React.FC<CancelButtonProps> = ({
  title,
  callback,
}) => {
  return (
    <button type="button" className="cancel-button" onClick={() => callback()}>
      {title}
    </button>
  );
};
